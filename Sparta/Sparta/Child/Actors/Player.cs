using Sparta.Child.Actors.ItemSystem;
using Sparta.NameSpace;
using Sparta.Parent;
using Sparta.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sparta.Child.Actors
{
    class Player : Actor
    {
        public Inventory inventory = new Inventory();

        private static Player? Instance = null;

        bool Init = false;



        public static Player GetPlayer()
        {
            AllItem.ItemInit();
            if (Instance == null)
            {
                Instance = new Player();
                Instance.BeginPlay();
            }
            return Instance;
        }

        public static Player GetPlayer(PlayerSaveData _SaveData)
        {
            AllItem.ItemInit();
            if (Instance == null)
            {
                Instance = new Player();
                Instance.LoadSaveData(_SaveData);
            }
            return Instance;
        }

        void SetStatus()
        {
            if (Job == "전사")
            {
                attack = 10;
                shield = 5;
                hp = 100;
                dex = 70;
            }
            else if (Job == "암살자")
            {
                attack = 15;
                shield = 3;
                hp = 80;
                dex = 70;
            }
            else if (Job == "탱커")
            {
                attack = 7;
                shield = 7;
                hp = 120;
                dex = 70;
            }
            else if (Job == "스파르타")
            {
                attack = 20;
                shield = 10;
                hp = 150;
                dex = 70;
            }

            Level = 1;
            gold = 1500;
            maxHp = hp;
            highestFloor = 1;
        }

        public PlayerSaveData MakeSaveData()
        {
            PlayerSaveData saveData = new PlayerSaveData();
            saveData.Name = Name;
            saveData.Job = Job;

            saveData.Level = Level;
            saveData.attack = attack;
            saveData.shield= shield;
            saveData.dex = dex;
            
            saveData.hp = hp;
            saveData.MaxHp = maxHp;

            saveData.Gold = gold;
            saveData.Exp = exp;
            saveData.requiredexp = requierdexp; // 요구 경험치 저장

            saveData.LastFloor = highestFloor;

            saveData.ListLength = inventory.inventory.Count();

            for (int i = 0; i < saveData.ListLength; ++i)
            {
                ItemSaveData ItemData = new ItemSaveData();
                Item item = inventory.inventory[i];
                string? ItemName = item.Name;

                ItemData.ItemName = ItemName;
                ItemData.IsEquipment = item.isEquip;

                saveData.ItemList.Add(ItemData);
            }


            return saveData;
        }

        public void LoadSaveData(PlayerSaveData _SaveData)
        {
            inventory.inventory.Clear();
            Name = _SaveData.Name;
            Job = _SaveData.Job;

            Level = _SaveData.Level;
            attack = _SaveData.attack;
            shield = _SaveData.shield;
            dex = _SaveData.dex;

            gold = _SaveData.Gold;

            hp = _SaveData.hp;
            maxHp = _SaveData.MaxHp;

            exp = _SaveData.Exp;
            requierdexp = _SaveData.requiredexp; // 요구 경험치 복원

            highestFloor = _SaveData.LastFloor;

            int ListLength = _SaveData.ListLength;

            for (int i = 0; i < ListLength; ++i)
            {
                ItemSaveData itemData = _SaveData.ItemList[i];
                Item item = AllItem.CreatItem(itemData.ItemName);
                inventory.inventory.Add(item);
                if (itemData.IsEquipment)
                {
                    inventory.inventory[i].isEquip = true;
                }
            }
        }

        void SelectName()
        {
            if (Init == true)
            {
                return;
            }
            Console.Clear();
            Console.WriteLine("이름을 알려주세요.\n");
            Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.Clear();
                Console.WriteLine("이름은 빈칸일 수 없습니다.\n");
                Key.AnyKey();
                BeginPlay();
                return;
            }

            while (true)
            {
                if (Init == true)
                {
                    return;
                }
                Console.Clear();
                Console.WriteLine($"입력하신 이름은 {Name}입니다.");
                Console.WriteLine("이름을 저장하시겠습니까?");
                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 취소\n");

                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case -1:
                        break;
                    case 1:
                        Console.WriteLine("이름이 저장되었습니다.\n");
                        Key.AnyKey();
                        return;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("이름을 다시 만듭니다.\n");
                        Key.AnyKey();
                        BeginPlay();
                        return;
                    default:
                        Key.WrongKey();
                        break;
                }
            }
        }
        void SelectJob()
        {
            if (Init == true)
            {
                return;
            }
            Console.Clear();
            int jobselect;
            string? JobNum;

            while (true)
            {
                if (Init == true)
                {
                    return;
                }
                Console.Clear();
                Console.WriteLine("직업을 선택해주세요.\n 1. 전사\n 2. 암살자\n 3. 탱커\n");

                JobNum = Console.ReadLine();


                if (JobNum == "스파르타")
                {
                    Job = "스파르타";
                }
                else if (int.TryParse(JobNum, out int result) == false)
                {
                    Console.WriteLine("잘못된 값을 입력하셨습니다.");
                    Key.AnyKey();
                    continue;
                }
                else if (int.Parse(JobNum) == 1)
                {
                    Job = "전사";
                }
                else if (int.Parse(JobNum) == 2)
                {
                    Job = "암살자";
                }
                else if (int.Parse(JobNum) == 3)
                {
                    Job = "탱커";
                }
                else
                {
                    Console.WriteLine("존재하는 직업을 선택해주세요\n");
                    Key.AnyKey();
                    continue;
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"입력하신 직업은 {Job}입니다.");
                    Console.WriteLine("직업을 선택하시겠습니까?");
                    Console.WriteLine("1. 저장");
                    Console.WriteLine("2. 취소\n");

                    selectedIndex = selector.Select();

                    switch (selectedIndex)
                    {
                        case -1:
                            break;
                        case 1:
                            Console.WriteLine("직업을 저장했습니다. 게임을 시작합니다.\n");
                            SetStatus();
                            Init = true;
                            Key.AnyKey();
                            return;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("직업을 다시 고릅니다.\n");
                            SelectJob();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Key.AnyKey();
                            break;
                    }

                }


            }
        }




        public override void BeginPlay()
        {
            ActType = ActorType.Player;
            Console.WriteLine("TextRPG 던전시커에 오신것을 환영합니다.");
            inventory.inventory.Add(AllItem.CreatItem(ItemName.LongSword));
            inventory.inventory.Add(AllItem.CreatItem(ItemName.LeatherArmour));
            inventory.inventory.Add(AllItem.CreatItem(ItemName.RedPotion));
            // 초기 장비 지급
            SelectName();
            SelectJob();
           // CheckLevel();
        }
       
        /// <summary> CheckLevel()
        /// 로드세이브에 스탯 제대로 적용되나 확인용 137,294줄에서 사용함.
        /// 78줄에 Lv을 수정하면 그 레벨만큼 스탯이 보정됨
        /// </summary>
        public void  CheckLevel()
        {
            if (Level > 1)
            {
                // 레벨 2부터 현재 레벨까지의 스탯 증가량 계산
                for (int i = 2; i <= Level; i++)
                {
                    maxHp += 10;       // 레벨당 최대 체력 증가
                    attack += 5;       // 레벨당 공격력 증가
                    shield += 2;       // 레벨당 방어력 증가
                    requierdexp *= 1.2f; // 다음 레벨업에 필요한 경험치 증가
                }

                // 현재 체력을 최대 체력으로 설정
                maxHp = hp;
                //hp = maxHp;
            }
            else if (Level == 1)
            {
                if (Job == "전사")
                {
                    attack = 10;
                    shield = 5;
                    maxHp = 100; // maxHp 설정
                    dex = 70;
                }
                else if (Job == "암살자")
                {
                    attack = 15;
                    shield = 3;
                    maxHp = 80; // maxHp 설정
                    dex = 70;
                }
                else if (Job == "탱커")
                {
                    attack = 7;
                    shield = 7;
                    maxHp = 120; // maxHp 설정
                    dex = 70;
                }
                else if (Job == "스파르타")
                {
                    attack = 20;
                    shield = 10;
                    maxHp = 150; // maxHp 설정
                    dex = 70;
                }
                hp = maxHp;

            }
        }
        public void PrintStatShort()
        {
            var (eqAttack, eqShield, eqHp) = inventory.GetEquippedStatTotal();
            totalAttack = attack + eqAttack;
            totalShield = shield + eqShield;
            totalHp = hp + eqHp;
            Console.WriteLine($"LV. {Level}\t | {Name}\t ( {Job} )");
            Console.WriteLine($"공격력 : {totalAttack}\t | 방어력 : {totalShield}\t | 체력 : {totalHp}\t");
        }
        public override void PrintStatus()
        {

            var (eqAttack, eqShield, eqHp) = inventory.GetEquippedStatTotal();
            totalAttack = attack + eqAttack;
            totalShield = shield + eqShield;
            totalHp = hp + eqHp;

            Console.WriteLine("Lv. " + Level);
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {attack + eqAttack} (+{eqAttack})");
            Console.WriteLine($"방어력 : {shield + eqShield} (+{eqShield})");
            Console.WriteLine($"체 력 : {hp + eqHp} (+{eqHp})");
            Console.WriteLine($"Gold : {gold} G");
            Console.WriteLine($"경험치 : {exp:F0}/{requierdexp:F0} ");
        }

        public void ExpGoldGet(float monsterexp, int monstergold)
        {
            exp += monsterexp;
            gold += monstergold;
            // 기본 메시지
            string message = $"경험치를 {monsterexp} 획득했습니다.\n골드를 {monstergold} G 획득했습니다.\n";

            // 레벨업 조건 확인
            while (exp >= requierdexp)
            {
                Level++;
                maxHp += 10;
                attack += 5;
                shield += 2;
                exp -= requierdexp;
                requierdexp *= 1.2f; // 다음 레벨업에 필요한 경험치 증가

                // 레벨업 메시지 추가
                message += $"{Name}이(가) 레벨업했습니다! 현재 레벨: {Level}\n";
            }

            // 최종 메시지 출력
            Console.WriteLine(message);
        }
        public void MonsterItemGet(List<Item> totalitem)
        {
            for (int i = 0; i < totalitem.Count; i++)
            {
                inventory.inventory.Add(totalitem[i]);
                Console.WriteLine($"전리품으로 {totalitem[i].Name} 장비를 획득했습니다.");
            }
        }
        public void HealHP(int Value)
        {
            hp += Value;

            if (hp > maxHp)
            {
                hp = maxHp;
            }
        }

        public void FullHP()
        {
            hp = maxHp;
        }

        protected override void OnDeath()
        {
            Console.WriteLine($"{Name}이(가) 사망했습니다. 마을로 귀환합니다...");
            hp = 1;
            // 게임 종료 처리 또는 재시작 유도
        }

        public override void Tick()
        {
            while (true)
            {
                base.Tick();
                Console.WriteLine("플레이어\n");
                Player.GetPlayer().PrintStatus();
                Console.WriteLine("\n0. 가방을 확인한다.");
                Console.WriteLine("1. 상태창을 닫는다.");

                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case -1:
                        break;
                    case 0:
                        inventory.Tick();
                        break;
                    case 1:
                        return;
                    default:
                        Key.WrongKey();
                        break;
                }
            }
        }

    }
}

using Sparta.Child.Actors.ItemSystem;
using Sparta.NameSpace;
using Sparta.Parent;
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


        public static Player GetPlayer()
        {
            if (Instance == null)
            {
                Instance = new Player();
                Instance.BeginPlay();
            }
            return Instance;
        }





        public override void BeginPlay()
        {
            ActType = ActorType.Player;
            Console.WriteLine("TextRPG 던전시커에 오신것을 환영합니다.");
            Console.WriteLine("이름을 알려주세요.\n");
            Name = Console.ReadLine();


            Console.Clear();
            Console.WriteLine($"입력하신 이름은 {Name}입니다.");
            Console.WriteLine("이름을 저장하시겠습니까?");
            Console.WriteLine("1. 저장");
            Console.WriteLine("2. 취소\n");

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 1:
                    Console.WriteLine("원하시는 행동을 입력해주세요\n");
                    break;
                case 2:
                    Console.Clear();
                    BeginPlay();
                    break;

                default:
                    Key.WrongKey();
                    break;
            }

            int jobselect;
            string? JobNum;

            while (true)
            {
                Console.WriteLine("직업을 선택해주세요.\n 1. 전사\n 2. 암살자\n 3. 탱커\n");
                JobNum = Console.ReadLine();

                if (JobNum != "1" && JobNum != "2" && JobNum != "3" && JobNum != "스파르타")
                {
                    Console.Clear();
                    Console.WriteLine("존재하는 직업을 선택해주세요\n");
                    continue;
                }
                else if (JobNum == "스파르타")
                {
                    Job = "스파르타";
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
                    return;
                }

                Console.Clear();
                Console.WriteLine($"입력하신 직업은 {Job}입니다.");
                Console.WriteLine("직업을 선택하시겠습니까?");
                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 취소\n");

                if (int.TryParse(Console.ReadLine(), out jobselect) && jobselect == 1)
                {
                    break;
                }

                Console.Clear();
            }

            if (Job == "전사")
            {
                attack = 10;
                shield = 5;
                hp = 100;
            }
            else if (Job == "암살자")
            {
                attack = 15;
                shield = 3;
                hp = 80;
            }
            else if (Job == "탱커")
            {
                attack = 7;
                shield = 7;
                hp = 120;
            }
            else if (Job == "스파르타")
            {
                attack = 20;
                shield = 10;
                hp = 150;
            }

            Level = 1;
            gold = 1500;
            maxHp = hp;

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
        }

        public void ExpGoldGet(float monsterexp, int monstergold)
        {
            exp += monsterexp;
            gold += monstergold;
            Console.WriteLine($"경험치를 {monsterexp} 획득했습니다.");
            Console.WriteLine($"골드를 {monsterexp} G 획득했습니다.");
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

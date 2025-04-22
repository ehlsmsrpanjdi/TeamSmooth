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



        int attack = 10;
        int shield = 5;
        int hp = 100;
        public int eqHp;
        public int maxHp => hp + eqHp;

        public override void BeginPlay()
        {
            ActType = ActorType.Player;
            Console.WriteLine("TextRPG 던전시커에 오신것을 환영합니다.");
            Console.WriteLine("이름을 알려주세요.\n");
            Name = Console.ReadLine();

            Level = 1;
            attack = 10;
            shield = 5;
            hp = 100;
            maxHp = 100;
            gold = 1500;

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
        }


        public override void PrintStatus()
        {

            var (eqAttack, eqShield, eqHp) = inventory.GetEquippedStatTotal();

            Console.WriteLine("Lv. " + Level);
            Console.WriteLine($"{Name} ( 전사 )");
            Console.WriteLine($"공격력 : {attack + eqAttack} (+{eqAttack})");
            Console.WriteLine($"방어력 : {shield + eqShield} (+{eqShield})");
            Console.WriteLine($"체 력 : {hp + eqHp} (+{eqHp})");
            Console.WriteLine($"Gold : {gold} G");
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


        public override void Tick()
        {
            while (true)
            {
                base.Tick();
                Console.WriteLine("플레이어\n");
                Player.GetPlayer().PrintStatus();
                Console.WriteLine("\n0. 가방을 확인한다.");
                Console.WriteLine("1. 나간다.");

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

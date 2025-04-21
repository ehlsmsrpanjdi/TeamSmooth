using Sparta.Child.Actors.ItemSystem;
using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Child.Actors
{
    class Player : Actor
    {
        Inventory inventory = new Inventory();

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
        }

        public override void PrintStatus()
        {
            Console.WriteLine("Lv. " + Level);
            Console.WriteLine($"{Name} ( 전사 )");
            Console.WriteLine($"공격력 : {attack} "); // (+{eqStr})");
            Console.WriteLine($"방어력 : {shield} "); // (+{eqDef})");
            Console.WriteLine($"체 력 : {hp} "); // (+{eqHp})");
            Console.WriteLine($"Gold : {gold} G");
        }

        public override void Tick()
        {
            while (true)
            {
                base.Tick();
                Console.WriteLine("플레이어\n");
                Player.GetPlayer().PrintStatus();
                Console.WriteLine("\n0. 가방을 확인한다.");
                Console.WriteLine("1. 무장을 확인한다.");
                Console.WriteLine("2. 나간다.");

                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case 0:
                        inventory.Tick();
                        break;
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                        return;
                    default:
                        Key.WrongKey();
                        break;
                }
            }
        }
    }
}

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

        public void Sell()
        {
            while (true)
            {
                Console.Clear();
                inventory.PrintOnly();

                Console.WriteLine("현재 소지금 : {0}\n\n", Player.GetPlayer().gold);

                Console.WriteLine("\n\n0. 판매한다.");
                Console.WriteLine("1. 나간다.");


                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("판매하고 싶은 아이템 번호를 적으시오");
                        int Index = selector.Select();
                        Console.WriteLine("판매하고 싶은 아이템 개수를 적으시오");
                        int count = selector.Select();
                        Player.GetPlayer().gold += inventory.SellItem(Index, count);
                        break;
                    case 1:
                        return;
                }
            }
        }

        public void GainItem(string _item)
        {
            inventory.GainItem(_item);
        }

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

        public void CheckInven()
        {
            if (Weapon != null)
            {
                Console.WriteLine("[E] {0}", Weapon.ItemName);
            }
            if (Armour != null)
            {
                Console.WriteLine("[E] {0}", Armour.ItemName);
            }
            if (Ring != null)
            {
                Console.WriteLine("[E] {0}", Ring.ItemName);
            }

        }

        public override void BeginPlay()
        {
            Level = 1;
            attack = 1;
            shield = 2;
            hp = 100;
            gold = 0;

            ActType = ActorType.Player;

            TakeOnItem(new LongSword());
            TakeOnItem(new LeatherArmour());
        }

        public override void Tick()
        {
            while (true)
            {
                base.Tick();
                Console.WriteLine("플레이어\n");

                Console.WriteLine("0. 가방을 확인한다.");
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
                        PrintStatus();
                        break;
                    case 2:
                        return;
                    default:
                        Key.WrongKey();
                        break;
                }
            }
        }

        public override void TakeOnItem(Item _item)
        {
            if (_item.Type == ItemType.Weapon)
            {
                if (Weapon != null)
                {
                    inventory.GainItem(Weapon.ItemName);
                }
                Weapon = _item;
            }
            else if (_item.Type == ItemType.Armour)
            {
                if (Armour != null)
                {
                    inventory.GainItem(Armour.ItemName);
                }
                Armour = _item;
            }
            else if (_item.Type == ItemType.Ring)
            {
                if (Ring != null)
                {
                    inventory.GainItem(Ring.ItemName);
                }
                Ring = _item;
            }
        }

        protected void TakeOffItem()
        {
            while (true)
            {
                Console.WriteLine("0. 나가기");
                Console.WriteLine("1. 무기 해제");
                Console.WriteLine("2. 방어구 해제");
                Console.WriteLine("3. 반지1 해제");
                Console.WriteLine("4. 반지2 해제");
                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case 0:
                        return;
                    case 1:
                        if (Weapon != null)
                        {
                            Weapon.TakeOff();
                            Weapon = null;
                        }
                        break;
                    case 2:
                        if (Armour != null)
                        {
                            Armour.TakeOff();
                            Armour = null;
                        }
                        break;
                    case 3:
                        if (Ring != null)
                        {
                            Ring.TakeOff();
                            Ring = null;
                        }
                        break;
                }
            }
        }
    }
}

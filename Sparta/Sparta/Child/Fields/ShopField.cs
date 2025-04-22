using Sparta.Child.Actors;
using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta.Child.Actors.ItemSystem;
using System.Numerics;

namespace Sparta.Child.Fields
{
    class ShopField : Field
    {
        Inventory inventory = new Inventory();


        public override void BeginPlay()
        {
            base.BeginPlay();
        }


        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("==============================");
            Console.WriteLine("=어서오세요 스무스 상점입니다=");
            Console.WriteLine("==============================");

            Console.WriteLine("구매하실 아이템을 선택해주세요.");
            Console.WriteLine();
            Console.WriteLine("현재 소지금 : {0}\n\n", Player.GetPlayer().gold);

            Console.WriteLine("0. 상태창");
            Console.WriteLine("1. 구매하기");
            Console.WriteLine("2. 판매하기");
            Console.WriteLine("3. 밖으로 나가기");
            Console.WriteLine();

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 0:
                    Player.GetPlayer().Tick();
                    break;
                case 1:
                    BuyItem();
                    break;
                case 2:
                    SellItem();
                    break;
                case 3:
                    ChangeField(FieldName.MainField);
                    break;
                default:
                    Key.WrongKey();
                    break;
            }
        }
        private void BuyItem()
        {
            List<Item> buyitem = new List<Item>
            {
                new Item { Name = "롱소드", addattack = 10, gold = 500 },
                new Item { Name = "가죽 갑옷", addshield = 5, gold = 500 },
                new Item { Name = "철 방패", addmaxHp = 5, gold = 500 },
                new Item { Name = "추가예정", addmaxHp = 0, gold = 0 },
                new Item { Name = "추가예정", addmaxHp = 0, gold = 0 },
                new Item { Name = "추가예정", addmaxHp = 0, gold = 0 }
            };
            Console.WriteLine("=========================");
            Console.WriteLine("=구매 가능한 아이템 목록=");
            Console.WriteLine("=========================");
            Console.WriteLine();
            for (int i = 0; i < buyitem.Count; i++)
            {
                Console.WriteLine($"{i}. {buyitem[i].Name} - 가격: {buyitem[i].gold} 골드");
            }
            Console.WriteLine($"{buyitem.Count}. 구매하지 않는다");
            Console.WriteLine();

            int choice = selector.Select();

            if (choice >= 0 && choice < buyitem.Count)
            {
                Item selectedItem = buyitem[choice];
                Player player = Player.GetPlayer();

                if (player.gold >= selectedItem.gold)
                {
                    player.gold -= selectedItem.gold;
                    Console.WriteLine($"{selectedItem.Name}을(를) 구매하였습니다!");
                    Key.AnyKey();
                }
                else
                {
                    Console.WriteLine("소지금이 부족합니다.");
                    Key.AnyKey();
                }
            }
        }
        public void SellItem()
        {
            Player player = Player.GetPlayer();

            while (player != null)
            {

                if (player.inventory.inventory.Count == 0)
                {
                    Console.WriteLine("판매할 아이템이 없습니다.");
                    Key.AnyKey();
                    break;
                }

                List<Item> sellitem = player.inventory.inventory;

                if (sellitem.Count == 0)
                {
                    Console.WriteLine("판매 가능한 아이템이 없습니다.");
                    Key.AnyKey();
                }

                Console.WriteLine("=========================");
                Console.WriteLine("=판매 가능한 아이템 목록=");
                Console.WriteLine("=========================");
                Console.WriteLine();
                for (int i = 0; i < sellitem.Count; i++)
                {
                    Console.WriteLine($"{i}. {sellitem[i].Name} - 가격: {sellitem[i].gold} 골드");
                }
                Console.WriteLine($"{sellitem.Count}. 판매하지 않는다");
                Console.WriteLine();

                int choice = selector.Select();

                if (choice >= 0 && choice < sellitem.Count)
                {
                    Item selectedItem = sellitem[choice];

                    player.gold += selectedItem.gold;
                    sellitem.Remove(selectedItem);
                    Console.WriteLine($"{selectedItem.Name}을(를) 판매하였습니다!");
                    Key.AnyKey();
                }
            }


        }
    }
}       
    





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

            Console.WriteLine("0. 상태창을 확인한다.");
            Console.WriteLine("1. 아이템을 구매한다.");
            Console.WriteLine("2. 소모품을 구매한다.");
            Console.WriteLine("3. 아이템을 판매한다.");
            Console.WriteLine("4. 상점에서 나간다.");
            Console.WriteLine();

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case -1:
                    break;
                case 0:
                    Player.GetPlayer().Tick();
                    break;
                case 1:
                    BuyItem();
                    break;
                case 2:
                    BuyUsingItem();
                    break;
                case 3:
                    SellItem();
                    break;
                case 4:
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
                AllItem.GetAllItem()[ItemName.LongSword],
                AllItem.GetAllItem()[ItemName.LeatherArmour],
                AllItem.GetAllItem()[ItemName.WoodShield],
                AllItem.GetAllItem()[ItemName.Broadsword],
                AllItem.GetAllItem()[ItemName.IronArmour],
                AllItem.GetAllItem()[ItemName.IronShield]
            };

            while (true) // 상점 아저씨가 쫒아내는 문제 해결
            {
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
                        player.inventory.inventory.Add(selectedItem); //구매시 플레이어 인벤토리로
                        Console.WriteLine($"{selectedItem.Name}을(를) 구매하였습니다!");
                        Key.AnyKey(); 
                        Console.Clear(); 
                    }
                    else
                    {
                        Console.WriteLine("소지금이 부족합니다.");
                        Key.AnyKey(); 
                        Console.Clear(); 
                    }

                }
                else if (choice == buyitem.Count)
                {
                    Console.WriteLine("구매를 취소하였습니다.");
                    break; //상점 밖으로 나갈 수 없던 문제 해결
                }
                else if (choice == -1)
                {
                    Console.Clear();
                    break;
                }
            }

        }

        private void BuyUsingItem()
        {
            List<Item> usingitem = new List<Item>
                {
                AllItem.GetAllItem()[ItemName.RedPotion],
                AllItem.GetAllItem()[ItemName.BigRedPotion],
                AllItem.GetAllItem()[ItemName.WhitePotion],
                AllItem.GetAllItem()[ItemName.BigWhitePotion]
            };

            while (true)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("=구매 가능한 아이템 목록=");
                Console.WriteLine("=========================");
                Console.WriteLine();
                for (int i = 0; i < usingitem.Count; i++)
                {
                    Console.WriteLine($"{i}. {usingitem[i].Name} \t- 가격: {usingitem[i].gold} 골드");
                }
                Console.WriteLine($"{usingitem.Count}. 구매하지 않는다");
                Console.WriteLine();

                int choice = selector.Select();

                if (choice >= 0 && choice < usingitem.Count)
                {
                    Item selectedItem = usingitem[choice];
                    Player player = Player.GetPlayer();

                    if (player.gold >= selectedItem.gold)
                    {
                        player.gold -= selectedItem.gold;
                        player.inventory.inventory.Add(selectedItem);
                        Console.WriteLine($"{selectedItem.Name}을(를) 구매하였습니다!");
                        Key.AnyKey(); 
                        Console.Clear(); 
                    }
                    else
                    {
                        Console.WriteLine("소지금이 부족합니다.");
                        Key.AnyKey(); 
                        Console.Clear(); 
                    }

                }
                else if (choice == usingitem.Count)
                {
                    Console.WriteLine("구매를 취소하였습니다.");
                    break; 
                }
                else if (choice == -1)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        public void SellItem()
        {
            Player player = Player.GetPlayer();

            while (true)
            {

                if (player.inventory.inventory.Count == 0)
                {
                    Console.WriteLine("판매할 아이템이 없습니다.");
                    Console.WriteLine();
                }

                List<Item> sellitem = player.inventory.inventory;

                if (sellitem.Count == 0)
                {
                    Console.WriteLine("판매 가능한 아이템이 없습니다.");
                    Console.WriteLine();
                }

                Console.WriteLine("=========================");
                Console.WriteLine("=판매 가능한 아이템 목록=");
                Console.WriteLine("=========================");
                Console.WriteLine();
                for (int i = 0; i < sellitem.Count; i++)
                {
                    Console.WriteLine($"{i}. {sellitem[i].Name} \t- 가격: {sellitem[i].gold} 골드");
                }
                Console.WriteLine($"{sellitem.Count}. 나가기");
                Console.WriteLine();

                int choice = selector.Select();

                if (choice >= 0 && choice < sellitem.Count)
                {
                    Item selectedItem = sellitem[choice];

                    player.gold += selectedItem.gold;
                    sellitem.Remove(selectedItem);
                    Console.WriteLine($"{selectedItem.Name}을(를) 판매하였습니다!");
                    Key.AnyKey(); 
                    Console.Clear(); 
                }
                else if (choice == sellitem.Count)
                {
                    Console.WriteLine("판매를 취소하였습니다.");
                    break;
                }
                else if (choice == -1)
                {
                    Console.Clear();
                    break;
                }
            }
        }
    }
}       
    





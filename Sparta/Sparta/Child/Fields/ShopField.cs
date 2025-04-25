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
            string[] itemNames = new string[]
            {
                 ItemName.LongSword,
                 ItemName.LeatherArmour,
                 ItemName.WoodShield,
                 ItemName.Broadsword,
                 ItemName.IronArmour,
                 ItemName.IronShield
            };

            while (true) // 상점 아저씨가 쫒아내는 문제 해결
            {
                Console.WriteLine("=========================");
                Console.WriteLine("=구매 가능한 아이템 목록=");
                Console.WriteLine("=========================");
                Console.WriteLine();

                // 아이템 이름을 기반으로 AllItem.GetAllItem()에서 아이템 가져오기
                for (int i = 0; i < itemNames.Length; i++)
                {
                    Item item = AllItem.GetAllItem()[itemNames[i]];
                    Console.WriteLine($"{i}. {item.Name} - 가격: {item.gold} 골드");
                }
                Console.WriteLine($"{itemNames.Length}. 구매하지 않는다");
                Console.WriteLine();

                int choice = selector.Select();

                if (choice >= 0 && choice < itemNames.Length)
                {
                    string selectedItemName = itemNames[choice];
                    Item selectedItem = AllItem.GetAllItem()[selectedItemName];
                    Player player = Player.GetPlayer();

                    if (player.gold >= selectedItem.gold)
                    {
                        player.gold -= selectedItem.gold;
                        player.GetPlayerInven().GetInventory().Add(selectedItem); //구매시 플레이어 인벤토리로
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
                else if (choice == itemNames.Length)
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
            string[] itemNames = new string[]
                {
                ItemName.RedPotion,
                ItemName.BigRedPotion,
                ItemName.WhitePotion,
                ItemName.BigWhitePotion
            };

            while (true)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("=구매 가능한 아이템 목록=");
                Console.WriteLine("=========================");
                Console.WriteLine();
                for (int i = 0; i < itemNames.Length; i++)
                {
                    Item item = AllItem.GetAllItem()[itemNames[i]];
                    Console.WriteLine($"{i}. {item.Name} - 가격: {item.gold} 골드");
                }
                Console.WriteLine($"{itemNames.Length}. 구매하지 않는다");
                Console.WriteLine();

                int choice = selector.Select();

                if (choice >= 0 && choice < itemNames.Length)
                {
                    string selectedItemName = itemNames[choice];
                    Item selectedItem = AllItem.GetAllItem()[selectedItemName];
                    Player player = Player.GetPlayer();

                    if (player.gold >= selectedItem.gold)
                    {
                        player.gold -= selectedItem.gold;
                        player.GetPlayerInven().GetInventory().Add(selectedItem);
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
                else if (choice == itemNames.Length)
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

                if (player.GetPlayerInven().GetInventory().Count == 0)
                {
                    Console.WriteLine("판매할 아이템이 없습니다.");
                    Console.WriteLine();
                }

                List<Item> sellitem = player.GetPlayerInven().GetInventory();

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
    





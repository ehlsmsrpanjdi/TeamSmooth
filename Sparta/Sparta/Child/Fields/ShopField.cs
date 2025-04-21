using Sparta.Child.Actors;
using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta.Child.Actors.ItemSystem;

namespace Sparta.Child.Fields
{
    class ShopField : Field
    {
        Inventory inventory = new Inventory();

        public override void BeginPlay()
        {
            base.BeginPlay();
            inventory.GainItem(ItemName.OrcArmour);
            inventory.GainItem(ItemName.FullPlateArmour);
            inventory.GainItem(ItemName.GreatSword);
        }

        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("상점입니다.");

            Console.WriteLine("현재 소지금 : {0}\n\n", Player.GetPlayer().gold);


            Console.WriteLine("0. 상태를 살핀다.");
            Console.WriteLine("1. 물건을 구매한다.");
            Console.WriteLine("2. 물건을 판매한다.");
            Console.WriteLine("3. 밖으로");

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 0:
                    Player.GetPlayer().Tick();
                    break;
                case 1:
                    Sell();
                    break;
                case 2:
                    Player.GetPlayer().Sell();
                    break;
                case 3:
                    ChangeField(FieldName.MainField);
                    break;
                default:
                    Key.WrongKey();
                    break;
            }
        }


        public void Sell()
        {
            while (true)
            {
                Console.Clear();
                inventory.PrintOnly();

                Console.WriteLine("\n\n0. 아이템 구매");
                Console.WriteLine("1. 나가기");

                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case 0:
                        Console.WriteLine("구매하고 싶은 아이템 번호를 적으시오");
                        int Index = selector.Select();

                        Item? tempitem = inventory.GetItemInfo(Index);
                        int gold;
                        if (tempitem != null)
                        {
                            gold = tempitem.price;
                        }
                        else
                        {
                            Console.WriteLine("올바르지 않은 선택지입니다.");
                            break;
                        }
                        if (Player.GetPlayer().gold < gold)
                        {
                            Console.WriteLine("골드가 부족합니다.");
                            Key.AnyKey();
                            break;
                        }
                        if (gold != 0 && tempitem != null)
                        {
                            inventory.SellItem(Index, 1);
                            Player.GetPlayer().GainItem(tempitem.ItemName);
                            Player.GetPlayer().gold -= gold;
                            Console.WriteLine("구매가 완료되었습니다.");
                            Key.AnyKey();
                            break;
                        }
                        break;
                    case 1:
                        ChangeField(FieldName.MainField);
                        return;
                    default:
                        Key.WrongKey();
                        break;
                }
            }
        }
    }
}

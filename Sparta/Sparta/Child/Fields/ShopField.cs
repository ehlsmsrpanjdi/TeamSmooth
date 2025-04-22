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


            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 0:
                    Player.GetPlayer().Tick();
                    break;
                case 1:
                    Console.WriteLine("구매할 아이템을 선택해주세요.");
                    break;
                case 2:
                    Console.WriteLine("판매할 아이템을 선택해주세요.");
                    break;
                case 3:
                    ChangeField(FieldName.MainField);
                    break;
                default:
                    Key.WrongKey();
                    break;
            }
        }


    }
}

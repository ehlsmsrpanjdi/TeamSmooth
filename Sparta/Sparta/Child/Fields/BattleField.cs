using Sparta.Child.Actors;
using Sparta.NameSpace;
using Sparta.Parent;
using Sparta.SelectorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Child.Fields
{
    class BattleField : Field
    {
        public override void BeginPlay()
        {
            base.BeginPlay();
        }


        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("마을 밖으로 나왔습니다.");

            Console.WriteLine("0. 상태창.");
            Console.WriteLine("1. 이동한다.");
            Console.WriteLine("2. 휴식을 취한다.");
            Console.WriteLine("3. 마을로 이동하기.");

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 0:
                    Player.GetPlayer().PrintStatus();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

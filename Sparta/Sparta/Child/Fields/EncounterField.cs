using Sparta.Child.Actors;
using Sparta.Child.Actors.MonsterSystem;
using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Child.Fields
{
    class EncounterField : Field
    {

        public override void BeginPlay()
        {
            base.BeginPlay();
        }

        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("당신은 적을 조우했습니다.");

            Console.WriteLine("1. 공격한다.");
            Console.WriteLine("2. 아이템을 확인한다.");
            Console.WriteLine("3. 도망을 시도한다.\n\n\n");

            Player.GetPlayer().PrintStatus();

            Console.WriteLine("============================\n\n");

            foreach (Actor act in Actors)
            {
                act.PrintStatus();
            }

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
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

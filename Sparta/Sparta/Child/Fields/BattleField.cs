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
        int Difficiulty = 0;
        int Range = 0;
        void Move()
        {
            if(Range > 0)
            {
                --Range;
            }
            Difficiulty++;
        }

        void Back()
        {
            Range++;
            if(Range >= 4)
            {
                ChangeField(FieldName.MainField);
            }
        }

        void Battle()
        {
            int enCounterProbability = Global.rand.Next(0, 100) + Difficiulty;

            if (enCounterProbability < 60)
            {
                return;
            }
            else
            {
                ChangeField(FieldName.EncounterField);
            }
        }

        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("당신은 마을 밖을 벗어났습니다.");

            Console.WriteLine("0. 상태를 살핀다.");
            Console.WriteLine("1. 이동한다.");
            Console.WriteLine("2. 휴식을 취한다.");
            Console.WriteLine("3. 마을 방향으로 이동한다.");

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 0:
                    Player.GetPlayer().PrintStatus();
                    break;
                case 1:
                    Move();
                    break;
                case 2:
                    break;
                case 3:
                    Back();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

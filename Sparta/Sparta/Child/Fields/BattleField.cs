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

        private void Move()
        {
            if(30 > Global.Rand(0, 100)){
                ChangeField(FieldName.EncounterField);
            }
        }

        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("마을 밖으로 나왔습니다.");

            Console.WriteLine("0. 상태창을 확인한다.");
            Console.WriteLine("1. 이동한다.");
            Console.WriteLine("2. 마을로 이동한다.");

            selectedIndex = selector.Select();

            switch (selectedIndex)
            {
                case -1:
                    break;
                case 0:
                    Player.GetPlayer().Tick();
                    break;
                case 1:
                    Move();
                    break;
                case 2:
                    ChangeField(FieldName.MainField);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

using Sparta.Child.Actors;
using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Child.Fields
{
    class MainField : Field
    {

        public override void BeginPlay()
        {
            base.BeginPlay();
        }


        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("메인 마을입니다");

            Console.WriteLine("0. 상태를 살핀다.");
            Console.WriteLine("1. 상점");
            Console.WriteLine("2. 여관");
            Console.WriteLine("3. 밖으로");

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 0:
                    Player.GetPlayer().Tick();
                    break;
                case 1:
                    ChangeField(FieldName.ShopField);
                    break;
                case 2:
                    ChangeField(FieldName.InnField);
                    break;
                case 3:
                    ChangeField(FieldName.BattleField);
                    break;
                default:
                    Key.WrongKey();
                    break;
            }
        }

        public override void BeginPlay()
        {
            base.BeginPlay();
        }

    }
}

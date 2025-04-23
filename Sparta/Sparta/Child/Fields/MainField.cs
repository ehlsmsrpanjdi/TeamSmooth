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
            Console.WriteLine("=======================================");
            Console.WriteLine("=환영합니다! 스무스 마을에 어서오세요.=");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("0. 상태창을 확인한다.");
            Console.WriteLine("1. 상점으로 간다.");
            Console.WriteLine("2. 여관으로 간다.");
            Console.WriteLine("3. 던전에 진입한다.");
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



    }
}

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
    class InnField : Field
    {

        public override void BeginPlay()
        {
            base.BeginPlay();
        }

        
        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("==============================");
            Console.WriteLine("=어서오세요 스무스 여관입니다=");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine("0. 상태창.");
            Console.WriteLine("1. 휴식하기.");
            Console.WriteLine("2. 여관에서 나간다.");
            Console.WriteLine();

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 0:
                    Player.GetPlayer().Tick();
                    break;
                case 1:
                    Console.WriteLine("휴식을 취합니다.");
                    Player player = Player.GetPlayer();
                    player.FullHP();
                    Console.WriteLine($"현재 체력: {player.maxHp}/{player.maxHp}");
                    Console.WriteLine("체력이 회복되었습니다.");
                    Key.AnyKey();
                    break;
                case 2:
                    ChangeField(FieldName.MainField);
                    break;
                default:
                    Key.WrongKey();
                    break;
            }
        }
    }
}

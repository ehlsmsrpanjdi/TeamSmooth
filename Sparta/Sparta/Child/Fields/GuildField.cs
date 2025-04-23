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
    class GuildField : Field
    {
        public override void BeginPlay()
        {
            base.BeginPlay();
            Console.WriteLine("길드에 입장했습니다.");
        }

        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("==============================");
            Console.WriteLine("=         시커 길드          =");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine("0. 상태창을 확인한다.");
            Console.WriteLine("1. 퀘스트를 진행한다.");
            Console.WriteLine("2. 퀘스트를 포기한다.");
            Console.WriteLine("3. 마을로 돌아간다.");
            Console.WriteLine();

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 0:
                    Player.GetPlayer().Tick();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    ChangeField(FieldName.MainField);
                    break;
                default:
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}


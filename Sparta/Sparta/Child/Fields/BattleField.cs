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

        Player player = Player.GetPlayer();


        private void Move()
        {

            base.Tick();
            Console.WriteLine("던전 층수를 선택해 주세요.");

            Console.WriteLine($"현재 선택 가능한 던전 층수 : 1 ~ {player.highestFloor}");
            Console.WriteLine("돌아가기 : 0\n");

            selectedIndex = selector.Select();

            switch (selectedIndex)
            {
                case -1:
                    Move();
                    break;
                case 0:
                    Tick();
                    break;
                case int selectFloor when 0 < selectFloor && selectFloor <= player.highestFloor :
                    EncounterMonster(selectFloor);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
                    Console.ReadKey();
                    Move();
                    break;
            }

        }

        private void EncounterMonster(int floorNum)
        {
            Console.WriteLine($"던전 {floorNum}층 몬스터와 조우했습니다.\n");

            ChangeField(FieldName.EncounterField);
            Key.AnyKey();
            Move();
        }

        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("마을 밖으로 나왔습니다.\n");

            Console.WriteLine("0. 상태창을 확인한다.");
            Console.WriteLine("1. 던전으로 이동한다.");
            Console.WriteLine("2. 마을로 이동한다.\n");

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

using Sparta.Child.Actors;
using Sparta.Child.Actors.MonsterSystem;
using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Child.Fields
{
    /// <summary>
    /// 플레이어 맞는거
    /// 플레이어 때리는거
    /// 
    /// 몬스터 때리는거
    /// 몬스터 맞는거
    /// 
    /// 몬스터 죽을 때 호출되어야 할 함수
    /// 플레이어 죽을 때 호출되어야 할 함수
    /// 
    /// 전투 중 아이템 사용
    /// </summary>


    class EncounterField : Field
    {

        public override void BeginPlay()
        {
            base.BeginPlay();
        }

        public override void FieldOpen()
        {
            base.FieldOpen();
            for (int i = 0; i < 4; i++)     // 몬스터는 최대 4마리 생성
            {
                if (30 < Global.Rand(0, 100))
                {
                    int monstertype = Global.Rand(0, 4); // 0이면 고블린, 1이면 오크, 2면 쌍두오크 생성
                    switch (monstertype)
                    {
                        case 0:
                            SpawnActor<Gobline>();
                            break;
                        case 1:
                            SpawnActor<Orc>();
                            break;
                        case 2:
                            SpawnActor<TwinHeadOrc>();
                            break;
                        case 3:
                            SpawnActor<Ogre>();
                            break;
                    }
                }
            }
        }

        private void PrintMonsterStatus()
        {
            Console.WriteLine("============================\n\n");
            for (int i = 1; i < Actors.Count() + 1; ++i)
            {
                Console.WriteLine("{0}번 몬스터", i);
                Actors[i - 1].PrintStatus();
                Console.WriteLine("\n");
            }
        }

        private bool RunAway()
        {
            if (30 > Global.Rand(0, 100))
            {
                Console.WriteLine("도망에 성공했습니다.");
                Key.AnyKey();
                ChangeField(FieldName.BattleField);
                return true;
            }
            else
            {
                Console.WriteLine("도망에 실패했습니다.");
                Key.AnyKey();
                return false;
            }
        }

        private void PlayerAttack()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("어떤 몬스터를 공격하십니까?");

                int select = selector.Select();
                if(select == -1)
                {
                    continue;
                }
                if (select <= 0 || select > Actors.Count())
                {
                    Key.WrongKey();
                    continue;
                }
                else
                {
                    Console.WriteLine("플레이어가 공격합니다\n");

                    if (true == Actors[select - 1].GetDamage(Player.GetPlayer().totalAttack, Actors[select - 1].totalShield))
                    {
                        Actors.Remove(Actors[select - 1]);
                    }

                    if(Actors.Count() == 0)
                    {
                        Console.WriteLine("플레이어가 승리하였습니다.");
                        ChangeField(FieldName.BattleField);
                        Key.AnyKey();
                        return;
                    }
                    Key.AnyKey();
                    return;
                }
            }
        }

        private void MonsterAttack()
        {
            Console.WriteLine("몬스터가 공격합니다\n");
            for (int i = 0; i < Actors.Count(); ++i)
            {
                if(true == Player.GetPlayer().GetDamage(Actors[i].totalAttack, Player.GetPlayer().totalShield))
                {
                    Console.WriteLine("마을로 이동됩니다.");
                    ChangeField(FieldName.MainField);
                    Key.AnyKey();
                    return;
                }
            }
            Key.AnyKey();
        }

        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("당신은 적을 조우했습니다.");

            Console.WriteLine("1. 공격한다.");
            Console.WriteLine("2. 아이템을 확인한다.");
            Console.WriteLine("3. 도망을 시도한다.\n");

            Player.GetPlayer().PrintStatShort();

            PrintMonsterStatus();

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case -1:
                    break;
                case 1:
                    PlayerAttack();
                    MonsterAttack();
                    break;
                case 2:
                    //플레이어 HP 회복 수단 및 아이템 변경 등등의 기능
                    //Player.GetPlayer().Tick();
                    break;
                case 3:
                    if (true == RunAway())
                    {
                        return;
                    }
                    MonsterAttack();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

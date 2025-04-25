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
        float TotalExp = 0;
        int TotalGold = 0;
        List<Item> TotalItem = new List<Item>();
        public override void BeginPlay()
        {
            base.BeginPlay();
            TotalExp = 0;
            TotalGold = 0;
            TotalItem.Clear();
        }

        public override void FieldOpen()
        {
            int minCount = difficulty/3 + 1;     // 최소 생성 마리 수
            int totalSpawn = 4;   // 몬스터 최대 수
            int spawnCount = 0;
            for (int i = 0; i < totalSpawn; i++)
            {
                bool mustSpawn = spawnCount < minCount;
                bool moreSpawn = (difficulty * 10 >= Global.Rand(0, 100));

                if (mustSpawn || moreSpawn)
                {
                    int rand = Global.Rand(0, 100);

                    if (rand < 20)
                    {
                        SpawnActor<Gobline>();
                    }
                    else if (rand < 60 && difficulty >= 3)
                    {
                        SpawnActor<Orc>();
                    }
                    else if (rand < 85 && difficulty >= 5)
                    {
                        SpawnActor<TwinHeadOrc>();
                    }
                    else if (difficulty >= 8)
                    {
                        SpawnActor<Ogre>();
                    }
                    else
                    {
                        SpawnActor<Gobline>();
                    }
                        spawnCount++;
                }
            }
        }

        private void PrintMonsterStatus()
        {
            Console.WriteLine("\n============================\n");
            for (int i = 1; i < Actors.Count() + 1; ++i)
            {
                Console.WriteLine("{0}번 몬스터", i);
                Actors[i - 1].PrintStatus();
                Console.WriteLine("");
            }
        }

        private bool RunAway()
        {
            if (difficulty*10 <= Global.Rand(0, 100))
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

                PrintMonsterStatus();

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

                    if (true == Actors[select - 1].GetDamage(Player.GetPlayer().totalAttack, Actors[select - 1].shield, Player.GetPlayer().dex, Actors[select - 1].dex))
                    {
                        TotalGold += Actors[select - 1].gold;
                        TotalExp += Actors[select - 1].exp;
                        for (int i = 0; i < Actors[select - 1].GetMonsterInven().Count; i++)
                        {
                            TotalItem.Add(Actors[select - 1].GetMonsterInven()[i]);
                        }
                        Actors.Remove(Actors[select - 1]);
                    }

                    if(Actors.Count() == 0)
                    {

                        if(difficulty == 10)
                        {
                            Console.WriteLine("\n     축하합니다! 던전의 최고층을 클리어하셨습니다!     \n\n");
                        }
                        else if(difficulty == Player.GetPlayer().highestFloor)
                        {
                            Player.GetPlayer().highestFloor++;
                        }

                        Console.WriteLine();
                        Console.WriteLine("플레이어가 승리하였습니다.\n");

                        Console.WriteLine("총 {0} 만큼의 경험치와, {1} 만큼의 골드를 획득했습니다!", TotalExp, TotalGold);
                        Player.GetPlayer().ExpGoldGet(TotalExp, TotalGold);
                        Player.GetPlayer().MonsterItemGet(TotalItem);
                        TotalExp = 0;
                        TotalGold = 0;
                        TotalItem.Clear();
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
            if(Actors.Count() == 0) { return; }
            Console.WriteLine("\n몬스터가 공격합니다\n");
            for (int i = 0; i < Actors.Count(); ++i)
            {
                if(true == Player.GetPlayer().GetDamage(Actors[i].attack, Player.GetPlayer().totalShield, Actors[i].dex, Player.GetPlayer().dex))
                {
                    Console.WriteLine("눈앞이 캄캄해집니다...");
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


            Player.GetPlayer().PrintStatShort();

            PrintMonsterStatus();

            Console.WriteLine($"현재 도전중인 층수 : {difficulty}층");


            Console.WriteLine("\n당신은 적을 조우했습니다.\n");

            Console.WriteLine("1. 공격한다.");
            Console.WriteLine("2. 아이템을 확인한다.");
            Console.WriteLine("3. 도망을 시도한다.\n");
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
                    Player.GetPlayer().Tick();
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

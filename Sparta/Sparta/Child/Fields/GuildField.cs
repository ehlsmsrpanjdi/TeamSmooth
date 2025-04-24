using Sparta.Child.Actors;
using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections;
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
        }

        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("==============================");
            Console.WriteLine("=         시커 길드          =");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine("0. 상태창을 확인한다.");
            Console.WriteLine("1. 퀘스트를 수주한다.");
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
                    OrderQuest();
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
        public void OrderQuest()
        {
            List<Quest> orderquest = new List<Quest>
    {
        new Quest { Name = "C급 퀘스트", Description = "고블린 10마리를 처치하세요.", Goal = 10, TargetMonster = MonsterName.Gobline, RewardGold = 40, RewardExp = 40 },
        new Quest { Name = "B급 퀘스트", Description = "오크 10마리를 처치하세요.", Goal = 10, TargetMonster = MonsterName.Orc, RewardGold = 60, RewardExp = 60 },
        new Quest { Name = "A급 퀘스트", Description = "쌍두오크 10마리를 처치하세요.", Goal = 10, TargetMonster = MonsterName.TwinHeadOrc, RewardGold = 80, RewardExp = 80 },
        new Quest { Name = "S급 퀘스트", Description = "오우거 10마리를 처치하세요.", Goal = 10, TargetMonster = MonsterName.Ogre, RewardGold = 100, RewardExp = 100 }
    };

            while (true)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("=수주 가능한 퀘스트 목록=");
                Console.WriteLine("=========================");
                Console.WriteLine();
                for (int i = 0; i < orderquest.Count; i++)
                {
                    Console.WriteLine($"{i}. {orderquest[i].Name} - 목표: {orderquest[i].TargetMonster} 토벌수량");
                }
                Console.WriteLine($"{orderquest.Count}. 수주하지 않는다");
                Console.WriteLine();
                break;
            }
        }
    }
}

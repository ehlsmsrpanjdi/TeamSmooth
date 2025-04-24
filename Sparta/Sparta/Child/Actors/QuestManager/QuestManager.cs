using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;

namespace Sparta.Child.Actors.QuestSystem
{
    public static class QuestManager
    {
        private static List<Quest> availableQuests = new List<Quest>(); // 수주 가능한 퀘스트
        private static List<Quest> activeQuests = new List<Quest>(); // 진행 중인 퀘스트

        // 초기화: 수주 가능한 퀘스트를 등록
        static QuestManager()
        {
            availableQuests.Add(new Quest { Name = "C급 퀘스트", Description = "고블린 10마리 토벌", Goal = 10, TargetMonster = MonsterName.Gobline, RewardGold = 40, RewardExp = 40 });
            availableQuests.Add(new Quest { Name = "B급 퀘스트", Description = "오크 10마리 토벌", Goal = 10, TargetMonster = MonsterName.Orc, RewardGold = 60, RewardExp = 60 });
            availableQuests.Add(new Quest { Name = "A급 퀘스트", Description = "쌍두오크 10마리 토벌", Goal = 10, TargetMonster = MonsterName.TwinHeadOrc, RewardGold = 80, RewardExp = 80 });
            availableQuests.Add(new Quest { Name = "S급 퀘스트", Description = "오우거 10마리 토벌", Goal = 10, TargetMonster = MonsterName.Ogre, RewardGold = 100, RewardExp = 100 });
        }

        // 퀘스트 목록을 출력하는 함수
        public static void GetQuest()
        {
            if (availableQuests.Count == 0)
            {
                Console.WriteLine("수주 가능한 퀘스트가 없습니다.");
                return;
            }

            for (int i = 0; i < availableQuests.Count; i++)
            {
                Console.WriteLine($"{i}. {availableQuests[i].Name} - {availableQuests[i].Description}");
            }
        }

        // 퀘스트 수주
        public static void AcceptQuest(int questIndex)
        {
            if (questIndex < 0 || questIndex >= availableQuests.Count)
            {
                Console.WriteLine("잘못된 선택입니다.");
                return;
            }

            Quest selectedQuest = availableQuests[questIndex];
            if (activeQuests.Contains(selectedQuest))
            {
                Console.WriteLine("이미 수주한 퀘스트입니다.");
                return;
            }

            activeQuests.Add(selectedQuest);
            Console.WriteLine($"'{selectedQuest.Name}' 퀘스트를 수주하였습니다!");
            Console.WriteLine();
        }
    }
}
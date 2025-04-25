using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;

namespace Sparta.Child.Actors.QuestSystem
{
    public static class QuestManager
    {
        private static List<Quest> GetQuests = new List<Quest>(); // 받을 수 있는 퀘스트 리스트
        private static List<Quest> QuestList = new List<Quest>(); // 진행중인 퀘스트 리스트

        // 초기화: 수주 가능한 퀘스트를 등록
        static QuestManager()
        {
            GetQuests.Add(new Quest { Name = "C급 퀘스트", Description = "고블린 10마리 토벌", Goal = 10, TargetMonster = MonsterName.Gobline, RewardGold = 1000, RewardExp = 100 });
            GetQuests.Add(new Quest { Name = "B급 퀘스트", Description = "오크 10마리 토벌", Goal = 10, TargetMonster = MonsterName.Orc, RewardGold = 1500, RewardExp = 150 });
            GetQuests.Add(new Quest { Name = "A급 퀘스트", Description = "쌍두오크 10마리 토벌", Goal = 10, TargetMonster = MonsterName.TwinHeadOrc, RewardGold = 2000, RewardExp = 200 });
            GetQuests.Add(new Quest { Name = "S급 퀘스트", Description = "오우거 10마리 토벌", Goal = 10, TargetMonster = MonsterName.Ogre, RewardGold = 2500, RewardExp = 250 });
        }

        // 퀘스트 목록을 출력하는 함수
        public static void GetQuest()
        {
            if (GetQuests.Count == 0)
            {
                Console.WriteLine("수주 가능한 퀘스트가 없습니다.");
                return;
            }

            for (int i = 0; i < GetQuests.Count; i++)
            {
                Console.WriteLine($"{i}. {GetQuests[i].Name} - {GetQuests[i].Description}");
            }
        }

        // 퀘스트 수주
        public static void AcceptQuest(int questIndex)
        {
            if (questIndex < 0 || questIndex >= GetQuests.Count)
            {
                Console.WriteLine("잘못된 선택입니다.");
                return;
            }

            Quest selectedQuest = GetQuests[questIndex];
            if (QuestList.Contains(selectedQuest))
            {
                Console.WriteLine("이미 수주한 퀘스트입니다.");
                return;
            }

            QuestList.Add(selectedQuest);
            Console.WriteLine($"'{selectedQuest.Name}' 퀘스트를 수주하였습니다!");
            Console.WriteLine();
        }
        public static void GetQuestList()
        {
            if (QuestList.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("진행 중인 퀘스트가 없습니다.");
                return;
            }

            Console.WriteLine("진행 중인 퀘스트 목록");
            Console.WriteLine();
            foreach (var quest in QuestList)
            {
                Console.WriteLine($"- {quest.Name}: {quest.Description} (진행 상황: {quest.Progress}/{quest.Goal})");
                Console.WriteLine();
                Console.WriteLine("아무키나 누르세요.");
            }
        }

        public static void UpdateQuest(string monsterName)
        {
            foreach (var quest in QuestList)
            {
                if (quest.TargetMonster == monsterName && !quest.IsCompleted)
                {
                    quest.Progress++;
                    Console.WriteLine($"'{quest.Name}' 진행 상황: {quest.Progress}/{quest.Goal}");

                    if (quest.IsCompleted) 
                    {
                        Console.WriteLine($"'{quest.Name}' 퀘스트를 완료했습니다!");
                    }
                }
            }

            QuestReward();

        }
        public static void QuestReward()
        {
            Player player = Player.GetPlayer(); 

            if (player == null)
            {
                Console.WriteLine("플레이어 객체를 찾을 수 없습니다.");
                return;
            }

            for (int i = QuestList.Count - 1; i >= 0; i--)
            {
                if (QuestList[i].IsCompleted)
                {
                    player.gold += QuestList[i].RewardGold;
                    player.AddExp(QuestList[i].RewardExp); //exp를 직접 수정할 수 없어서 plaer에 addexp함수 만들고 사용

                    Console.WriteLine($"'{QuestList[i].Name}' 퀘스트 보상 수령: 골드 {QuestList[i].RewardGold}, 경험치 {QuestList[i].RewardExp}");

                    QuestList.RemoveAt(i); // 퀘스트 완료하고 리스트에서 퀘스트 제거
                }
            }
        }
    }
}
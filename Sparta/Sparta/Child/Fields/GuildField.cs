using Sparta.Child.Actors;
using Sparta.Child.Actors.QuestSystem;
using Sparta.NameSpace;
using Sparta.Parent;
using System;

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
            Console.WriteLine("1. 퀘스트를 수주한다.");
            Console.WriteLine("2. 퀘스트를 확인한다.");
            Console.WriteLine("3. 길드에서 나간다.");
            Console.WriteLine();

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 1:
                    OrderQuest();
                    break;
                case 2:
                    CheckQuest();
                    break;
                case 3:
                    ChangeField(FieldName.MainField);
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }

        private void OrderQuest()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("=수주 가능한 퀘스트 목록=");
            Console.WriteLine("=========================");
            Console.WriteLine();
            QuestManager.GetQuest(); // 퀘스트 목록 출력

            Console.WriteLine();
            int questIndex = selector.Select();

            QuestManager.AcceptQuest(questIndex); // 퀘스트 수주
            Console.ReadKey();
        }

        private void CheckQuest()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("=   수주한 퀘스트 목록   =");
            Console.WriteLine("==========================");
            Console.WriteLine();
            QuestManager.GetQuestList(); // 퀘스트 목록 출력
            Console.ReadKey();
        }
    }
}



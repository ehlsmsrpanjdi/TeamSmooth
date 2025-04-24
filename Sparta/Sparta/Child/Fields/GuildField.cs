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
            Console.WriteLine("2. 마을로 돌아간다.");
            Console.WriteLine();

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case 1:
                    OrderQuest();
                    break;
                case 2:
                    ChangeField(FieldName.MainField);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. 아무 키나 누르세요...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        private void OrderQuest()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("=수주 가능한 퀘스트 목록=");
            Console.WriteLine("=========================");
            QuestManager.GetQuest(); // 퀘스트 목록 출력

            Console.WriteLine("수주할 퀘스트 번호를 입력하세요:");
            int questIndex = selector.Select();

            QuestManager.AcceptQuest(questIndex); // 퀘스트 수주
            Console.WriteLine("아무 키나 누르세요...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta.Child.Actors;

namespace Sparta.Parent
{
    public class Quest
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int Goal { get; set; } = 0; // 목표 수량
        public int Progress { get; set; } = 0; // 현재 진행 상황
        public string TargetMonster { get; set; } = ""; // 목표 몬스터
        public int RewardGold { get; set; } = 0; // 보상 골드
        public int RewardExp { get; set; } = 0; // 보상 경험치
        public bool IsCompleted => Progress >= Goal; // 완료 여부

        public void PrintQuestStatus()
        {
            Console.WriteLine($"퀘스트: {Name}");
            Console.WriteLine($"설명: {Description}");
            Console.WriteLine($"진행 상황: {Progress}/{Goal}");
            Console.WriteLine($"보상: {RewardGold} 골드, {RewardExp} 경험치");
        }

    }
}
﻿using Sparta.Child.Actors.QuestSystem;
using Sparta.Parent;

namespace Sparta.Child.Actors.MonsterSystem
{
    class Monster : Actor
    {
        private List<Item> monsterInven = new List<Item>();
        public Monster()
        {

        }
        public List<Item> GetMonsterInven()
        {
            if (monsterInven != null)
                return monsterInven;
            else
                return monsterInven = new List<Item>();
        }
        public override void PrintStatus()
        {
            Console.Write("Lv. " + Level);
            Console.WriteLine($" {Name}");
            Console.Write($"공격력 : {attack} \t"); // (+{eqStr})");
            Console.Write($" | 방어력 : {shield} \t"); // (+{eqDef})");
            Console.WriteLine($" | 체력 : {hp} \t"); // (+{eqHp})");
        }
        protected override void OnDeath()
        {
            base.OnDeath();
            //Player.GetPlayer().ExpGoldGet(exp, gold); 몬스터가 죽을 때 함수 실행
            QuestManager.UpdateQuest(this.Name); //몬스터 죽을때 불러오기
        }
    }
}

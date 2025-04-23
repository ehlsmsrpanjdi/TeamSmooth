using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta.Child.Actors.ItemSystem;

namespace Sparta.Child.Actors.MonsterSystem
{
    class Monster : Actor
    {
        public Monster()
        {

        }
        public override void PrintStatus()
        {
            Console.Write("Lv. " + Level);
            Console.WriteLine($" {Name}");
            Console.Write($"공격력 : {attack} \t"); // (+{eqStr})");
            Console.Write($" | 방어력 : {shield} \t"); // (+{eqDef})");
            Console.WriteLine($" | 체 력 : {hp} \t"); // (+{eqHp})");
        }
        protected override void OnDeath()
        {
            base.OnDeath();
            //Player.GetPlayer().ExpGoldGet(exp, gold); 몬스터가 죽을 때 함수 실행
        }
    }
}

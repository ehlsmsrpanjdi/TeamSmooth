using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Sparta.SelectorSystem;
using Sparta.NameSpace;
using Sparta.Child.Actors.ItemSystem;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Sparta.Parent
{
    public enum ActorType
    {
        None = -1,
        Player = 0,
        Monster,
    }
    public class Actor
    {
        public Actor() { }

        public virtual void BeginPlay()
        {

        }

        public virtual void Tick()
        {
            Console.Clear();
        }

        public virtual void PrintStatus()   //상태를 출력하는 함수입니다.
        {
            Console.WriteLine("Lv. " + Level);
            Console.WriteLine($"{Name} ( {Job} )");
            Console.WriteLine($"공격력 : {attack} "); // (+{eqStr})");
            Console.WriteLine($"방어력 : {shield} "); // (+{eqDef})");
            Console.WriteLine($"체 력 : {hp} "); // (+{eqHp})");
            Console.WriteLine($"Gold : {gold} G");
        }


        public virtual void PrintItem()
        {
            if (Weapon != null)
            {
                Weapon.PrintItem();
            }
            else
            {
                Console.WriteLine("무기 없음\n");
            }
            if (Armour != null)
            {
                Armour.PrintItem();
            }
            else
            {
                Console.WriteLine("방어구 없음\n");
            }
            if (Ring != null)
            {
                Ring.PrintItem();
            }
            else
            {
                Console.WriteLine("장신구 없음\n");
            }

        }
        /// <summary>
        /// 첫 번째 인자는 공격자의 총 공격력, 두 번째 인자는 방어자의 총 방어력입니다.
        /// 세 번째 인자는 공격자의 민첩, 네 번째 인자는 방어자의 민첩입니다.
        /// 추후 좀 더 간결하게 수정할 예정입니다.
        /// </summary>
        /// <param name="attackerTotalAttack"></param>
        /// <param name="defenderTotalShield"></param>
        /// <returns></returns>
        public virtual bool GetDamage(int attackerTotalAttack, int defenderTotalShield, int attackerDex, int defenderDex)
        {
            Random random = new Random();
            int damage = Math.Max(1, attackerTotalAttack - defenderTotalShield);

            // 회피 계산
            if (random.Next(0, 100) < defenderDex/2)
            {
                Console.WriteLine($"{Name}이(가) 공격을 회피했습니다!");
                return false; // 전투 계속
            }

            // 치명타 계산
            bool isCritical = false;
            isCritical=random.Next(0, 100) < attackerDex;
            if (isCritical)
            {
                damage = (int)(damage * 1.5); // 치명타 데미지 1.5배
                Console.WriteLine("치명타 발생!");
            }

            // 데미지 적용
            hp -= damage;
            if (hp < 0)
                hp = 0;

            Console.WriteLine($"{Name}이(가) {damage}의 피해를 입었습니다. 현재 체력: {hp}/{maxHp}");

            if (hp == 0)
            {
                OnDeath();
                return true; // 사망
            }

            return false; // 전투 계속
        }

        // 사망 시 실행될 함수 (필요시 오버라이드 가능)
        protected virtual void OnDeath()
        {
            Console.WriteLine($"{Name}이(가) 사망했습니다.\n");
            // 여기서 전투 종료, 제거 처리 등 추가 가능
        }

        


        public Item? Weapon = null;
        public Item? Armour = null;
        public Item? Ring = null;

        public string? Name {  get; set; }
        public string? Job { get; set; } // 전직(Class 가 맞는 거 같은데 단어 혼동이 클 거 같음 ㅇㅇ;;) 
        public int highestFloor { get; set; }
        public int Level { get; protected set; }
        public int attack { get; protected set; }
        public int shield { get; protected set; }
        public int hp { get; protected set; }
        public int dex { get; protected set; } //치명타,회피 발생 확률 관련 스탯
        public int maxHp { get; protected set; }
        public int gold { get;  set; }
        public float exp { get; protected set; }
        public int totalAttack { get; set; }
        public int totalShield { get; set; }
        public int totalHp  { get; set; }
        public float requierdexp { get; protected set; } = 100;
        


        protected Selector selector = new Selector();
        protected int selectedIndex = 0;

        protected ActorType ActType = ActorType.None;
    }
}

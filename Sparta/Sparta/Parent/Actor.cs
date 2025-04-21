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
            Console.WriteLine($"{Name} ( 전사 )");
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




        public Item? Weapon = null;
        public Item? Armour = null;
        public Item? Ring = null;

        public string Name {  get; set; }
        public int Level { get; protected set; }
        public int attack { get; protected set; }
        public int shield { get; protected set; }
        public int hp { get; protected set; }
        public int maxHp { get; protected set; }
        public int gold { get;  set; }
        public float exp { get; protected set; }


        protected Selector selector = new Selector();
        protected int selectedIndex = 0;

        protected ActorType ActType = ActorType.None;
    }
}

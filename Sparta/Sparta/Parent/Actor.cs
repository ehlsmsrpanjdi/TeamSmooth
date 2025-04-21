using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Sparta.SelectorSystem;
using Sparta.NameSpace;
using Sparta.Child.Actors.ItemSystem;

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

        public void PrintStatus()
        {
            int ItemAttack = 0;
            int ItemShield = 0;
            int ItemHp = 0;
            if (Weapon != null)
            {
                ItemAttack += Weapon.attack;
                ItemShield += Weapon.shield;
                ItemHp += Weapon.hp;
            }
            if (Armour != null)
            {
                ItemAttack += Armour.attack;
                ItemShield += Armour.shield;
                ItemHp += Armour.hp;
            }


            Console.WriteLine("레벨 : {0}", Level);
            Console.WriteLine("현재 공격력: {0} + {1}", attack, ItemAttack);
            Console.WriteLine("현재 방어력: {0} + {1}", shield, ItemShield);

            if (ActType == ActorType.Player)
            {
                Console.WriteLine("현재 체력: {0}", hp);
                Console.WriteLine("소지 금액 : {0}\n\n\n\n", gold);
            }
            else
            {
                Console.WriteLine("\n\n");
            }

                PrintItem();

            Key.AnyKey();
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

        public virtual void TakeOnItem(Item _item)
        {
            if (_item.Type == ItemType.Weapon)
            {
                Weapon = _item;
                _item.TakeOn();
            }
            else if (_item.Type == ItemType.Armour)
            {
                Armour = _item;
                _item.TakeOn();
            }
            else if (_item.Type == ItemType.Ring)
            {
                Ring = _item;
                _item.TakeOn();
            }

        }

        public void LevelUp()
        {
            ++Level;
            float attackValue = (float)attack * LevelUpValue;
            float shieldValue = (float)attack * LevelUpValue;
            float hpValue = (float)attack * LevelUpValue;

            attack = (int)attackValue;
            shield = (int)shieldValue;
            hp = (int)hpValue;
        }



        public Item? Weapon = null;
        public Item? Armour = null;
        public Item? Ring = null;


        public int Level { get; protected set; }
        public int attack { get; protected set; }
        public int shield { get; protected set; }
        public int hp { get; protected set; }
        public int currenthp { get; protected set; }
        public int gold { get;  set; }
        public float exp { get; protected set; }

        public float LevelUpValue = 1.1f;

        protected Selector selector = new Selector();
        protected int selectedIndex = 0;

        protected ActorType ActType = ActorType.None;
    }
}

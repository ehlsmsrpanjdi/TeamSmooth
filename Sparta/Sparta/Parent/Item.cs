using Sparta.NameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Sparta.Child.Actors;

namespace Sparta.Parent
{
    public struct ItemStatus
    {
        public string Name;
        public string? Info;
        public int attack;
        public int shield;
        public int hp;
    }

    public enum ItemType
    {
        Weapon = 0,
        Armour,
        shield,
        Potion,
    }
    public class Item : Actor
    {
        public ItemType myItemType;
        public string? Info = null;     // 장비 설명
        public bool isEquip = false;    // 장착 여부
        public int addattack = 0;       // 장비 추가 능력치
        public int addshield = 0;
        public int addmaxHp = 0;

        public override void PrintStatus()
        {
            Console.Write("- {0} {1}", isEquip ? "[E]" : "", Name);
            if (addshield > 0)
                Console.Write("| 방어력 +{0} ", addshield);
            if (addattack > 0)
                Console.Write("| 공격력 +{0} ", addattack);
            if (addmaxHp > 0)
                Console.Write("| 최대 HP +{0} ", addmaxHp);
            Console.WriteLine("| {0} | {1} G", Info, gold);
        }
        public void EquipManageStatus(int i)
        {
            Console.Write("-{0}. {1} {2}", i + 1, isEquip ? "[E]" : "", Name);
            if (addshield > 0)
                Console.Write("| 방어력 +{0} ", addshield);
            if (addattack > 0)
                Console.Write("| 공격력 +{0} ", addattack);
            if (addmaxHp > 0)
                Console.Write("| 최대 HP +{0} ", addmaxHp);
            Console.WriteLine("| {0} | {1} G", Info, gold);
        }

        public ItemStatus GetItemStatus()
        {
            ItemStatus status = new ItemStatus();
            status.Name = Name;
            status.attack = attack;
            status.shield = shield;
            status.hp = hp;
            status.Info = Info;
            return status;
        }

    }
}

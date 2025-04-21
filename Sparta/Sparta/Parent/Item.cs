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
    public enum ItemType
    {
        Weapon = 0,
        Armour,
        Ring,
    }
    public class Item : Actor
    {
        ItemType myItemType;
        public string? Info = null;
        public bool isEquip = false;
        public override void PrintStatus()
        {
            if (Name != null)
            {
                Console.Write("- ");
                Console.Write("{0}", isEquip ? "[E]" : ""); // 장착 중일 경우 [E] 가 붙고 아니면 안 붙음
                Console.Write("{0}  ", Name);
                if (Armour != null)
                    Console.Write("| 방어력 +{0} ", shield);
                if (Weapon != null)
                    Console.Write("| 공격력 +{0} ", attack);
                Console.Write("| {0} ", Info);
                Console.Write("| {0} G\n", gold);
            }
        }
    }
}

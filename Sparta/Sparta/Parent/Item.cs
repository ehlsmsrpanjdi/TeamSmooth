using Sparta.NameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Parent
{
    public enum ItemType {
        Weapon = 0,
        Armour,
        Ring,
    }
    public class Item : Actor
    {
        public override void PrintItem()
        {
            switch (Type)
            {
                case ItemType.Weapon:
                    Console.WriteLine("무기");
                    break;
                case ItemType.Armour:
                    Console.WriteLine("방어구");
                    break;
                case ItemType.Ring:
                    Console.WriteLine("장신구");
                    break;
            }
            Console.WriteLine("아이템 이름: {0}", ItemName);
            Console.WriteLine("아이템 공격력: {0}", attack);
            Console.WriteLine("아이템 방어력: {0}\n", shield);

        }

        public void TakeOn()
        {
            equipment = true;
        }

        public void TakeOff()
        {
            equipment = false;
        }
        public ItemType Type { get; set; }


        public bool equipment = false;
        public string ItemName { get; protected set; } = "NoNamed";
        public int price { get; protected set; } = 100;
    }
}

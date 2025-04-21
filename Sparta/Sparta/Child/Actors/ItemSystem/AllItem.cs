using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Sparta.NameSpace;

namespace Sparta.Child.Actors.ItemSystem
{
    public class AllItem
    {
        public static Dictionary<string, Item> Items = null;

        static void ItemInit()
        {
            Dictionary<string, Item> Items = GetAllItem();
            Items[ItemName.LongSword] = new LongSword();
            Items[ItemName.LeatherArmour] = new LeatherArmour();
            Items[ItemName.NormalRing] = new NormalRing();
        }

        public static Item? GetItem(string _itemName)
        {
            if (Items.ContainsKey(_itemName) == false)
            {
                Key.WrongKey();
            }
            return Items[_itemName];
        }

        public static Dictionary<string, Item> GetAllItem()
        {
            if(Items == null)
            {
                Items = new Dictionary<string, Item>();
            }
            return Items;
        }
    }

    public class LongSword : Item
    {
        public LongSword()
        {
            myItemType = ItemType.Weapon;

        }
    }

    public class LeatherArmour : Item
    {
        public LeatherArmour()
        {
            myItemType = ItemType.Armour;

        }
    }

    public class NormalRing : Item
    {
        public NormalRing()
        {
            myItemType = ItemType.Ring;

        }
    }
}

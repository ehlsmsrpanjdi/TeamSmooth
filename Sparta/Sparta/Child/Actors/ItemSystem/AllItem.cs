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

        public static void ItemInit()
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
        public static Item CreatItem(string _itemName)       // 도감에 있는 아이템을 실제 장비 아이템으로 생성하는 함수
        {
            Item gened_item = new Item();
            gened_item.Name = Items[_itemName].Name;
            gened_item.addattack = Items[_itemName].addattack;
            gened_item.addshield = Items[_itemName].addshield;
            gened_item.addmaxHp = Items[_itemName].addmaxHp;
            gened_item.gold = Items[_itemName].gold;
            gened_item.Info = Items[_itemName].Info;
            gened_item.myItemType = Items[_itemName].myItemType;
            return gened_item;
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
            Name = ItemName.LongSword;
            isEquip = false;
            addattack = 10;
            gold = 1000;
            Info = "적당히 긴 길이의 검입니다.";
        }
    }

    public class LeatherArmour : Item
    {
        public LeatherArmour()
        {
            myItemType = ItemType.Armour;
            Name = ItemName.LeatherArmour;
            isEquip = false;
            addshield = 10;
            gold = 1000;
            Info = "흔한 가죽으로 만든 갑옷입니다.";
        }
    }

    public class NormalRing : Item
    {
        public NormalRing()
        {
            myItemType = ItemType.Ring;
            Name = ItemName.NormalRing;
            isEquip = false;
            gold = 1000;
            Info = "평범하지만 나름의 은은한 매력이 있는 반지입니다.";
        }
    }
}

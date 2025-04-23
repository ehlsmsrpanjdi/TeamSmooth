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
            Items[ItemName.WoodShield] = new WoodShield();
            Items[ItemName.Broadsword] = new Broadsword();
            Items[ItemName.IronArmour] = new Ironarmour();
            Items[ItemName.IronShield] = new Ironshield();
            Items[ItemName.RedPotion] = new RedPotion();
            Items[ItemName.BigRedPotion] = new BigRedPotion();
            Items[ItemName.WhitePotion] = new WhitePotion();
            Items[ItemName.BigWhitePotion] = new BigWhitePotion();
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
            gold = 500;
            Info = "길이가 긴 검입니다.";
        }
    }
    public class LeatherArmour : Item
    {
        public LeatherArmour()
        {
            myItemType = ItemType.Armour;
            Name = ItemName.LeatherArmour;
            isEquip = false;
            addshield = 5;
            gold = 500;
            Info = "가죽으로 만든 갑옷입니다.";
        }
    }
    public class WoodShield : Item
    {
        public WoodShield()
        {
            myItemType = ItemType.shield;
            Name = ItemName.WoodShield;
            isEquip = false;
            addmaxHp = 5;
            gold = 500;
            Info = "나무로 만든 방패입니다.";
        }
    }
    public class Broadsword : Item
    {
        public Broadsword()
        {
            myItemType = ItemType.Weapon;
            Name = ItemName.Broadsword;
            isEquip = false;
            addattack = 20;
            gold = 1000;
            Info = "두껍고 무거운 검입니다.";
        }
    }
    public class Ironarmour : Item
    {
        public Ironarmour()
        {
            myItemType = ItemType.Armour;
            Name = ItemName.IronArmour;
            isEquip = false;
            addshield = 10;
            gold = 1000;
            Info = "철로 만든 갑옷입니다.";
        }
    }
    public class Ironshield : Item
    {
        public Ironshield()
        {
            myItemType = ItemType.shield;
            Name = ItemName.IronShield;
            isEquip = false;
            addshield = 10;
            gold = 1000;
            Info = "철로 만든 방패입니다.";
        }
    }
    public class RedPotion : Item
    {
        public RedPotion()
        {
            myItemType = ItemType.Potion;
            Name = ItemName.RedPotion;
            isEquip = false;
            addmaxHp = 20;
            gold = 100;
            Info = "체력을 회복합니다.";
        }
    }
    public class BigRedPotion : Item
    {
        public BigRedPotion()
        {
            myItemType = ItemType.Potion;
            Name = ItemName.BigRedPotion;
            isEquip = false;
            addshield = 40;
            gold = 200;
            Info = "체력을 많이 회복합니다.";
        }
    }
    public class WhitePotion : Item
    {
        public WhitePotion()
        {
            myItemType = ItemType.Potion;
            Name = ItemName.WhitePotion;
            isEquip = false;
            addshield = 60;
            gold = 400;
            Info = "체력을 크게 회복합니다.";
        }
    }
    public class BigWhitePotion : Item
    {
        public BigWhitePotion()
        {
            myItemType = ItemType.Potion;
            Name = ItemName.BigWhitePotion;
            isEquip = false;
            addshield = 80;
            gold = 800;
            Info = "체력을 아주 크게 회복합니다.";
        }
    }


}

using Sparta.NameSpace;
using Sparta.Parent;
using Sparta.SelectorSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Child.Actors.ItemSystem
{
    public class Inventory
    {
        public Inventory()
        {
            if (DictionaryInit != true)
            {
                ItemInfo[ItemName.LongSword] = new LongSword();
                ItemInfo[ItemName.LeatherArmour] = new LeatherArmour();
                ItemInfo[ItemName.OrcArmour] = new OrcArmour();
                ItemInfo[ItemName.OrcSword] = new OrcSword();
                ItemInfo[ItemName.FullPlateArmour] = new FullPlateArmour();
                ItemInfo[ItemName.GreatSword] = new GreatSword();
                DictionaryInit = true;
            }
        }

        public void Tick()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("장착한 장비\n");
                Player.GetPlayer().CheckInven();
                Console.WriteLine("\n\n현재 가방을 살피는 중입니다.\n\n");


                Console.WriteLine("0. 장비를 확인한다.");
                Console.WriteLine("1. 잡동사니를 확인한다.");
                Console.WriteLine("2. 나간다.");

                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case 0:
                        Print();
                        break;
                    case 1:
                        break;
                    case 2:
                        return;
                    default:
                        break;
                }
            }
        }
        public void GainItem(string _itmeName)
        {
            if (Inven.ContainsKey(_itmeName))
            {
                ++Inven[_itmeName];
            }
            else
            {
                Inven[_itmeName] = 1;
            }
        }

        public int SellItem(int _Num, int _Count)
        {
            int index = 1;
            foreach (KeyValuePair<string, int> pair in Inven)
            {
                if (_Num == index)
                {
                    string key = pair.Key;
                    if (Inven[pair.Key] > _Count)
                    {
                        Inven[pair.Key] -= _Count;
                        int Value = ItemInfo[pair.Key].price * _Count;
                        return Value;
                    }
                    else if (Inven[pair.Key] == _Count)
                    {
                        int Value = ItemInfo[pair.Key].price * _Count;
                        Inven.Remove(pair.Key);
                        return Value;
                    }
                }
                ++index;
            }
            Console.WriteLine("개수가 모자랍니다");
            Key.AnyKey();
            return 0;
        }

        public Item? GetItem(int _index)
        {
            int index = 1;
            foreach (KeyValuePair<string, int> pair in Inven)
            {
                if (_index == index)
                {
                    string key = pair.Key;
                    --Inven[pair.Key];
                    if (Inven[pair.Key] == 0)
                    {
                        Inven.Remove(pair.Key);
                    }
                    return ItemInfo[pair.Key];
                }
                ++index;
            }
            return null;
        }

        public int Buy(string _itemName, int _count)
        {
            if (ItemInfo.ContainsKey(_itemName))
            {
                Item item = ItemInfo[_itemName];
                if (Inven.ContainsKey(_itemName))
                {
                    Inven[_itemName] += _count;
                    return _count * item.price;
                }
                else
                {
                    Inven[_itemName] = _count;
                    return _count * item.price;
                }
            }
            return 0;
        }


        public Item? GetItemInfo(int _index)
        {
            int index = 1;
            foreach (KeyValuePair<string, int> pair in Inven)
            {
                if (_index == index)
                {
                    string key = pair.Key;
                    return ItemInfo[key];
                }
                ++index;
            }
            return null;
        }

        public void PrintItemInfo(int _index)
        {
            int index = 1;
            foreach (KeyValuePair<string, int> pair in Inven)
            {
                if (_index == index)
                {
                    string key = pair.Key;
                    ItemInfo[key].PrintItem();
                    Key.AnyKey();
                    return;
                }
                ++index;
            }
            Console.WriteLine("잘못된 입력입니다.");
            Key.AnyKey();
            return;
        }

        public void PrintOnly()
        {
            int index = 1;
            if (Inven.Count() == 0)
            {
                Console.WriteLine("아무것도 소유하고 있지 않습니다.");
                return;
            }

            foreach (KeyValuePair<string, int> pair in Inven)
            {
                Console.Write("{0} : ", index++);
                Console.WriteLine("{0} X {1}", pair.Key, pair.Value);
            }
        }

        public void Print()
        {
            while (true)
            {
                Console.Clear();
                PrintOnly();
                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("0. 장비 정보를 확인한다.");
                Console.WriteLine("1. 장비를 장착한다.");
                Console.WriteLine("2. 나간다.");

                selectedIndex = selector.Select();
                int number = 0;
                switch (selectedIndex)
                {
                    case 0:
                        number = selector.Select();
                        PrintItemInfo(number);
                        break;
                    case 1:
                        Console.WriteLine("\n");
                        Console.WriteLine("몇 번 장비를 장착할 것인가?");
                        number = selector.Select();
                        Item? item = GetItem(number);
                        if (item != null)
                        {
                            Player.GetPlayer().TakeOnItem(item);
                        }
                        else
                        {
                            Key.WrongKey();
                        }
                        break;
                    case 2:
                        return;
                }
            }
        }

        Dictionary<string, int> Inven = new Dictionary<string, int>();

        static Dictionary<string, Item> ItemInfo = new Dictionary<string, Item>();
        static bool DictionaryInit = false;

        protected Selector selector = new Selector();
        protected int selectedIndex = 0;
    }


    class LongSword : Item
    {
        public LongSword()
        {
            Type = ItemType.Weapon;
            attack = 10;
            ItemName = "장검";
            price = 100;
        }
    }


    class LeatherArmour : Item
    {
        public LeatherArmour()
        {
            Type = ItemType.Armour;
            shield = 3;
            ItemName = "가죽갑옷";
            price = 100;
        }
    }

    class OrcArmour : Item
    {
        public OrcArmour()
        {
            Type = ItemType.Armour;
            shield = 2;
            ItemName = "오크갑옷";
            price = 50;
        }
    }

    class OrcSword : Item
    {
        public OrcSword()
        {
            Type = ItemType.Armour;
            shield = 5;
            ItemName = "오크장검";
            price = 50;
        }
    }

    class FullPlateArmour : Item
    {
        public FullPlateArmour()
        {
            Type = ItemType.Armour;
            shield = 12;
            ItemName = "판금갑옷";
            price = 500;
        }
    }

    class GreatSword : Item
    {
        public GreatSword()
        {
            Type = ItemType.Weapon;
            shield = 2;
            attack = 20;
            ItemName = "대검";
            price = 400;
        }
    }
}
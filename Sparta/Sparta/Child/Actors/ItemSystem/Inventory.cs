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
        List<Item> inventory = new List<Item>();

        public Inventory()
        {
            if (AllItem.Items != null)
            {
                Item item_base = AllItem.CreatItem(ItemName.LongSword);
                item_base.Name = "초보자의 장검";
                item_base.isEquip = true;
                item_base.addattack = 11;
                inventory.Add(item_base);
            }
        }

        public void Tick()
        {
            while (true)
            {
                Console.WriteLine("-인벤토리-\n보유 중인 아이템을 확인합니다.\n");
                Console.WriteLine("\n[아이템 목록]\n");

                for (int i = 0; i < inventory.Count; i++) // 개인적으로 foreach 싫어서 for 문으로 제작
                {
                    inventory[i].PrintStatus();
                    AllItem.GetItem(ItemName.LongSword).PrintStatus();
                }
                Console.WriteLine("\n1. 장착 관리\n2. 나가기");
                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case 0:
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
        protected Selector selector = new Selector();
        protected int selectedIndex = 0;
    }

}
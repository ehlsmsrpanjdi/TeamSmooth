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
    class Inventory
    {
        public List<Item> inventory = new List<Item>();
        EquipManage EquipManage = new EquipManage();

        private static Inventory? Instance = null;
        public static Inventory GetInventory()
        {
            if (Instance == null)
            {
                Instance = new Inventory();
            }
            return Instance;
        }

        public Inventory()
        {
            if (AllItem.Items != null)
            {
                inventory.Add(AllItem.CreatItem(ItemName.LongSword));
                inventory.Add(AllItem.CreatItem(ItemName.LeatherArmour));
                inventory.Add(AllItem.CreatItem(ItemName.LeatherArmour));
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
                    //AllItem.GetItem(ItemName.LongSword).PrintStatus(); // 도감에 들어있는 정보가 훼손이 안되는지 테스트 하기 위한 코드
                }
                Console.WriteLine("\n1. 장착 관리\n2. 나가기");
                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case 1:
                        EquipManage.Tick();
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
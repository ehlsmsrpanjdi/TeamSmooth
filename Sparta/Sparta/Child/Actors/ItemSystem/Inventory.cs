﻿using Sparta.NameSpace;
using Sparta.Parent;
using Sparta.SelectorSystem;

namespace Sparta.Child.Actors.ItemSystem
{
    class Inventory
    {
        List<Item> inventory = new List<Item>();
        EquipManage EquipManage = new EquipManage();
        public Inventory()
        {

        }
        public List<Item> GetInventory()
        {
            if (inventory != null)
                return inventory;
            else
                return inventory = new List<Item>();
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
                Console.WriteLine("\n1. 장비장착 및 아이템을 사용한다.\n2. 가방을 닫는다.");
                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case -1:
                        Console.Clear();
                        break;
                    case 1:
                        EquipManage.Tick();
                        break;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        protected Selector selector = new Selector();
        protected int selectedIndex = 0;
        public void OnlyOnePartItem(ItemType itemtype, int index)       // 중복 착용 방지 함수
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (i != index)
                {
                    if (inventory[i].myItemType == itemtype && inventory[i].isEquip)
                    {
                        inventory[i].isEquip = false;
                        Console.WriteLine("{0} 장비를 {1}했습니다.\n", inventory[i].Name, inventory[i].isEquip ? "장착" : "해제");
                    }
                }
            }
        }
        public (int totalStr, int totalDef, int totalHp) GetEquippedStatTotal()
        {
            int totalStr = 0;
            int totalDef = 0;
            int totalHp = 0;

            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].isEquip)
                {
                    totalStr += inventory[i].addattack;
                    totalDef += inventory[i].addshield;
                    totalHp += inventory[i].addmaxHp;
                }
            }
            return (totalStr, totalDef, totalHp);
        }
    }
}
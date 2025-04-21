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
            // 테스트용 장비 생성
            Item item_Test = new Item();
            item_Test.Name = "정머의 종이조각";
            item_Test.gold = 100;
            item_Test.Info = "아무짝에도 쓸모없는 종이조각이다.";
            item_Test.Weapon = item_Test;
            item_Test.isEquip = true;
            // 장비 정보 저장 후 인벤토리 배열에 넣기
            inventory.Add(item_Test);

        }

        public void Tick()
        {
            while (true)
            {
                Console.WriteLine("-인벤토리-\n보유 중인 아이템을 확인합니다.\n");
                Console.WriteLine("\n[아이템 목록]\n");
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i] != null)
                    {
                        inventory[i].PrintStatus(); // 인벤토리 배열에 저장되어 있는 아이템 정보창 출력
                    }
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
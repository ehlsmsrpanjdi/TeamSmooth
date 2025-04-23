using Sparta.NameSpace;
using Sparta.Parent;
using Sparta.SelectorSystem;
using System.ComponentModel.Design;

namespace Sparta.Child.Actors.ItemSystem
{
    public class EquipManage
    {
        public void Tick()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-장착 관리-\n보유 중인 아이템을 장착하거나 해제합니다.(포션은 장착을 하면 사용이 됩니다.)\n");
                Player.GetPlayer().PrintStatus();
                Console.WriteLine("\n[아이템 목록]\n");
                List<Item> inventory = Player.GetPlayer().inventory.inventory;

                for (int i = 0; i < inventory.Count; i++) // 개인적으로 foreach 싫어서 for 문으로 제작
                {
                    inventory[i].EquipManageStatus(i);
                }
                Console.WriteLine("\n0. 장비 착용을 중단한다.");
                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case -1:
                        break;
                    case 0:
                        return;
                    default:
                        if (selectedIndex - 1 < inventory.Count)
                        {
                            if (inventory[selectedIndex - 1].myItemType != ItemType.Potion)
                            {
                                inventory[selectedIndex - 1].isEquip = !inventory[selectedIndex - 1].isEquip;
                                Player.GetPlayer().inventory.OnlyOnePartItem(inventory[selectedIndex - 1].myItemType, selectedIndex - 1);
                                Console.WriteLine("{0} 장비를 {1}했습니다.\n", inventory[selectedIndex - 1].Name, inventory[selectedIndex - 1].isEquip ? "장착" : "해제");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("{0} 을(를) 사용하여 체력을 {1} 회복했습니다.\n", inventory[selectedIndex - 1].Name, inventory[selectedIndex - 1].addmaxHp);
                                Player.GetPlayer().HealHP(inventory[selectedIndex - 1].addmaxHp);
                                inventory.Remove(inventory[selectedIndex - 1]);
                                break;
                            }    
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
        protected Selector selector = new Selector();
        protected int selectedIndex = 0;
    }
}

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
                Console.WriteLine("-장착 관리-\n보유 중인 아이템을 장착하거나 해제합니다.\n");
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
                                Console.WriteLine("포션은 장착할 수 없습니다.\n");
                                break;
                            }    
                        }
                        else
                        {
                            Key.WrongKey();
                        }
                        break;
                }
            }
        }
        protected Selector selector = new Selector();
        protected int selectedIndex = 0;
    }
}

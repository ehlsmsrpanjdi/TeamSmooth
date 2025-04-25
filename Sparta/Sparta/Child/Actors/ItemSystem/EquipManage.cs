using Sparta.NameSpace;
using Sparta.Parent;
using Sparta.SelectorSystem;

namespace Sparta.Child.Actors.ItemSystem
{
    public class EquipManage
    {
        public void Tick()
        {
            while (true)
            {
                Console.WriteLine("-장착 및 사용 관리-\n보유 중인 아이템을 장착,해제 및 사용합니다.\n");
                Player.GetPlayer().PrintStatus();
                Console.WriteLine("\n[아이템 목록]\n");
                List<Item> inventory = Player.GetPlayer().GetPlayerInven().GetInventory();
                for (int i = 0; i < inventory.Count; i++) // 개인적으로 foreach 싫어서 for 문으로 제작
                {
                    inventory[i].EquipManageStatus(i);
                }
                Console.WriteLine("\n0. 장비 장착을 중단한다.");
                selectedIndex = selector.Select();
                switch (selectedIndex)
                {

                    case -1:
                        Console.Clear();
                        break;
                    case 0:
                        return;
                    default:
                        if (selectedIndex - 1 < inventory.Count)
                        {
                            Item selectItem = inventory[selectedIndex - 1];
                            switch (selectItem.myItemType)
                            {
                                case ItemType.Potion:
                                    Console.WriteLine("{0} 을(를) 사용하여 체력을 {1} 회복했습니다.\n", inventory[selectedIndex - 1].Name, inventory[selectedIndex - 1].addmaxHp);
                                    Player.GetPlayer().HealHP(inventory[selectedIndex - 1].addmaxHp);
                                    inventory.Remove(inventory[selectedIndex - 1]);
                                    Key.AnyKey();
                                    Console.Clear();
                                    break;
                                default:
                                    inventory[selectedIndex - 1].isEquip = !inventory[selectedIndex - 1].isEquip;
                                    Player.GetPlayer().GetPlayerInven().OnlyOnePartItem(inventory[selectedIndex - 1].myItemType, selectedIndex - 1);
                                    Console.WriteLine("{0} 장비를 {1}했습니다.\n", inventory[selectedIndex - 1].Name, inventory[selectedIndex - 1].isEquip ? "장착" : "해제");
                                    Key.AnyKey();
                                    Console.Clear();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                }
            }
        }
        protected Selector selector = new Selector();
        protected int selectedIndex = 0;
    }
}

using Sparta.Child.Actors;
using Sparta.Child.Actors.ItemSystem;
using Sparta.NameSpace;
using Sparta.Parent;

namespace Sparta.Child.Fields
{
    class MainField : Field
    {
        bool ishidden = false;
        bool hiddenEvent = false;
        public override void BeginPlay()
        {
            base.BeginPlay();
        }
        public override void Tick()
        {

            ishidden = false;
            if (!hiddenEvent)
            {
                if (5 > Global.Rand(0, 100))
                    ishidden = true;
            }
            // n프로 확률로 5번 선택지가 등장
            base.Tick();
            Console.WriteLine("=======================================");
            Console.WriteLine("=환영합니다! 스무스 마을에 어서오세요.=");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("0. 상태창을 확인한다.");
            Console.WriteLine("1. 상점으로 간다.");
            Console.WriteLine("2. 여관으로 간다.");
            Console.WriteLine("3. 길드로 간다.");
            Console.WriteLine("4. 마을 밖으로 나간다.");
            if (ishidden == true)
                Console.WriteLine("5. 눈이 부신 곳을 향해 간다...");
            Console.WriteLine();

            selectedIndex = selector.Select();
            switch (selectedIndex)
            {
                case -1:
                    break;
                case 0:
                    Player.GetPlayer().Tick();
                    break;
                case 1:
                    ChangeField(FieldName.ShopField);
                    break;
                case 2:
                    ChangeField(FieldName.InnField);
                    break;
                case 3:
                    ChangeField(FieldName.GuildField);
                    break;
                case 4:
                    ChangeField(FieldName.BattleField);
                    break;
                case 5:
                    if (ishidden)
                    {
                        Hidden_1();
                        break;
                    }
                    else
                    {
                        Key.WrongKey();
                        break;
                    }
                default:
                    Key.WrongKey();
                    break;
            }
        }
        public void Hidden_1()
        {
            while (true)
            {
                int luckynum = Global.Rand(1, 3);
                Console.WriteLine("당신은 알 수 없는 빛에 이끌려 신비한 곳에 도착했습니다.");
                Console.WriteLine("올바른 선택을 하면 당신에게 좋은 일이 일어날 것 같습니다.");
                Console.WriteLine("당신의 행운을 시험해 보세요!.\n");
                Console.WriteLine("1. 더 앞으로 나아간다. \n2. 뒤로 돌아간다.\n");
                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case 1:
                        OneOrTwo();
                        return;
                    case 2:
                        OneOrTwo();
                        return;
                    case -1:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                void OneOrTwo()
                {
                    if (selectedIndex != luckynum)
                    {
                        Console.WriteLine("유감... 알 수 없는 빛이 사라졌습니다...\n");
                        Key.AnyKey();
                    }
                    else
                    {
                        Console.WriteLine("축하합니다!. 당신은 빛의 축복을 받아 특별한 장비를 획득했습니다.\n");
                        Key.AnyKey();
                        Player.GetPlayer().GetPlayerInven().GetInventory().Add(AllItem.CreatItem(ItemName.DivineBlade));
                        hiddenEvent = true;
                    }
                }
            }
        }
    }
}


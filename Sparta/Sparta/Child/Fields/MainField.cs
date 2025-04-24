using Sparta.Child.Actors;
using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Child.Fields
{
    class MainField : Field
    {
        bool ishidden = false;
        public override void BeginPlay()
        {
            base.BeginPlay();
        }


        public override void Tick()
        {
            ishidden = false ;
            if (5 > Global.Rand(0,100))
                ishidden = true;            // n프로 확률로 5번 선택지가 등장
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
                        // 히든 무기를 획득 하는 함수
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



    }
}

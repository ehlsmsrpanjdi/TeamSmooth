using Sparta.Child.Fields;
using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta.Child;
using Sparta.Child.Actors;

namespace Sparta.Child
{
    class TextRpg : MainGame
    {
        private static TextRpg? Instance = null;
        public static TextRpg GetInst()
        {
            if (Instance == null)
            {
                Instance = new TextRpg();
            }
            return Instance;
        }


        public override void Start()
        {
            Instance = this;
            bool selectedcomplete = false;
            while (!selectedcomplete)
            {
                Console.Clear();
                Console.WriteLine("0. 게임 시작하기");
                Console.WriteLine("1. 게임 불러오기");
                Console.WriteLine("99. 게임 종료");

                selectedIndex = selector.Select();

                switch (selectedIndex)
                {
                    case 0:
                        CreateField<MainField>(FieldName.MainField);
                        CreateField<BattleField>(FieldName.BattleField);
                        CreateField<EncounterField>(FieldName.EncounterField);
                        CreateField<ShopField>(FieldName.ShopField);
                        CreateField<InnField>(FieldName.InnField);
                        Player.GetPlayer();

                        FieldChange(FieldName.MainField);
                        base.Start();
                        selectedcomplete = true;
                        break;
                    case 1:
                        break;
                    case 99:
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Key.AnyKey();
                        break;
                }
            }
        }

    }


}


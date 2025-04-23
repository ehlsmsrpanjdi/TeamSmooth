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
using Sparta.Child.Actors.ItemSystem;

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
                Console.WriteLine("=================================");
                Console.WriteLine("=          Text RPG             =");
                Console.WriteLine("=          던전 시커            =");
                Console.WriteLine("=================================");
                Console.WriteLine();
                Console.WriteLine("0. 게임 시작하기");
                Console.WriteLine("1. 게임 불러오기");
                Console.WriteLine("99. 게임 종료");
                Console.WriteLine();

                selectedIndex = selector.Select();

                switch (selectedIndex)
                {
                    case -1:
                        break;
                    case 0:
                        CreateField<MainField>(FieldName.MainField);
                        CreateField<BattleField>(FieldName.BattleField);
                        CreateField<EncounterField>(FieldName.EncounterField);
                        CreateField<ShopField>(FieldName.ShopField);
                        CreateField<InnField>(FieldName.InnField);
                        CreateField<GuildField>(FieldName.GuildField);
                        AllItem.ItemInit();
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
                        Key.WrongKey();
                        break;
                }
            }
        }

    }


}


using Sparta.Child.Actors.ItemSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.NameSpace
{
    public static class Key
    {
        public static void AnyKey()
        {
            Console.WriteLine("아무키나 누르시오");
            Console.ReadKey();
        }

        public static void WrongKey()
        {
            Console.WriteLine("잘못된 입력입니다.  아무키나 누르시오");
            Console.ReadKey();
        }
    }


    public static class FieldName
    {
        public const string MainField = "main";
        public const string ShopField = "shop";
        public const string InnField = "inn";
        public const string BattleField = "battlefield";
        public const string EncounterField = "encounterField";
    }

    public static class ItemName
    {
        public const string LongSword = "장검";
        public const string LeatherArmour = "가죽갑옷";
        public const string OrcArmour = "오크갑옷";
        public const string OrcSword = "오크장검";
        public const string GreatSword = "대검";
        public const string FullPlateArmour = "판금갑옷";
    }


    public static class Global
    {
        public static Random rand = new Random();
    }
}

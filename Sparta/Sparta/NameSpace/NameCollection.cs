﻿using Sparta.Child.Actors.ItemSystem;
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
            Console.WriteLine("잘못된 입력입니다. 아무키나 누르시오");
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
        public const string GuildField = "GuildField";
    }

    public static class ItemName
    {
        public const string LongSword = "롱소드";
        public const string LeatherArmour = "가죽갑옷";
        public const string WoodShield = "나무방패";
        public const string Broadsword = "브로드소드";
        public const string IronArmour = "철갑옷";
        public const string IronShield = "철방패";
        public const string DivineBlade = "신성한 칼날";
        public const string RedPotion = "빨간물약";
        public const string BigRedPotion = "큰 빨간물약";
        public const string WhitePotion = "하얀물약";
        public const string BigWhitePotion = "큰 하얀물약";
    }
    public static class MonsterName
    {
        public const string Gobline = "고블린";
        public const string Orc = "오크";
        public const string TwinHeadOrc = "쌍두오크";
        public const string Ogre = "오우거";
    }
    public static class JobName
    {
        public const string Warrior = "전사";
        public const string Assassin = "암살자";
        public const string Tanker = "탱커";
        public const string Sparta = "스파르타";
        public const string Monster = "몬스터";
    }

    public static class QuestName
    {
        public const string EseyQuest = "C급 퀘스트";
        public const string NomalQuest = "B급 퀘스트";
        public const string HardQuest = "A급 퀘스트";
        public const string VeryHardQuest = "S급 퀘스트";
    }

    public static class Global
    {
        public static Random rand = new Random();

        public static int Rand(int _min, int _max)
        {
            return Global.rand.Next(_min, _max);
        }
    }
}

﻿using Sparta.Child.Actors;
using Sparta.NameSpace;
using Sparta.Parent;
using Sparta.SaveSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Child.Fields
{
    class InnField : Field
    {

        public override void BeginPlay()
        {
            base.BeginPlay();
        }

        
        public override void Tick()
        {
            base.Tick();
            Console.WriteLine("==============================");
            Console.WriteLine("=어서오세요 스무스 여관입니다=");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine("0. 상태창을 확인한다.");
            Console.WriteLine("1. 휴식을 취한다.");
            Console.WriteLine("2. 여관에서 나간다.");
            Console.WriteLine("3. 저장한다.");
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
                    Console.WriteLine("휴식을 취합니다.");
                    Player player = Player.GetPlayer();
                    player.FullHP();
                    Console.WriteLine($"현재 체력: {player.totalMaxHp}/{player.totalMaxHp}");
                    Console.WriteLine("체력이 회복되었습니다.");
                    Key.AnyKey();
                    break;
                case 2:
                    ChangeField(FieldName.MainField);
                    break;
                case 3:
                    SaveManager saveManager = new SaveManager();
                    saveManager.Save();
                    break;
                default:
                    Key.WrongKey();
                    break;
            }
        }
    }
}

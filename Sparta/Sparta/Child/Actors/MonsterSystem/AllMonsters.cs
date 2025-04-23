using Sparta.NameSpace;
using Sparta.Parent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta.Child.Actors.ItemSystem;

namespace Sparta.Child.Actors.MonsterSystem
{
    class Gobline : Monster
    {
        public Gobline()
        {
            Name = MonsterName.Gobline;
            Job = JobName.Monster;
            attack = 5;
            shield = 0;
            maxHp = 20;
            hp = maxHp;
            exp = 10;
            gold = Global.Rand(0, 100);
        }
    }

    class Orc : Monster
    {
        public Orc() 
        {
            Name = MonsterName.Orc;
            Job = JobName.Monster;
            attack = 5;
            shield = 5;
            maxHp = 40;
            hp = maxHp;
            exp = 15;
            gold = Global.Rand(0, 100);
        }
    }

    class TwinHeadOrc : Monster
    {
        public TwinHeadOrc()
        {
            Name = MonsterName.TwinHeadOrc;
            Job = JobName.Monster;
            attack = 10;
            shield = 5;
            maxHp = 60;
            hp = maxHp;
            exp = 20;
            gold = Global.Rand(0, 100);
        }
    }

    class Ogre : Monster
    {
        public Ogre()
        {
            Name = MonsterName.Ogre;
            Job = JobName.Monster;
            attack = 20;
            shield = 10;
            maxHp = 100;
            exp = 25;
            hp = maxHp;
            gold = Global.Rand(0, 100);
        }
    }
}

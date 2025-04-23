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
    class Gobline : Actor
    {
        public Gobline()
        {
            Name = MonsterName.Gobline;
            Job = JobName.Monster;
            attack = 5;
            shield = 0;
            maxHp = 60;
            hp = maxHp;
            gold = Global.Rand(0, 100);
        }
    }

    class Orc : Actor
    {
        public Orc() 
        {
            Name = MonsterName.Gobline;
            Job = JobName.Monster;
            attack = 5;
            shield = 5;
            maxHp = 120;
            hp = maxHp;
            gold = Global.Rand(0, 100);
        }   
    }

    class TwinHeadOrc : Actor
    {
        public TwinHeadOrc()
        {
            Name = MonsterName.Gobline;
            Job = JobName.Monster;
            attack = 10;
            shield = 5;
            maxHp = 150;
            hp = maxHp;
            gold = Global.Rand(0, 100);
        }
    }

    class Ogre : Actor
    {
        public Ogre()
        {
            Name = MonsterName.Ogre;
            Job = JobName.Monster;
            attack = 50;
            shield = 20;
            maxHp = 120;
            hp = maxHp;
            gold = Global.Rand(0, 100);
        }
    }
}

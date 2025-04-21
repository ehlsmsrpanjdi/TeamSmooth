using Sparta.NameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Parent
{
    public enum ItemType {
        Weapon = 0,
        Armour,
        Ring,
    }
    public class Item : Actor
    {
        ItemType myItemType;
    }
}

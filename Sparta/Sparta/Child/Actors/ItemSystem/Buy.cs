using Sparta.NameSpace;
using Sparta.Parent;
using Sparta.SelectorSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Child.Actors.ItemSystem
{
    internal class Buy
    {
        public static Buy? Instance = null;
        public static Buy GetBuyItem()
        {
            if (Instance == null)
            {
                Instance = new Buy();
                AllItem.ItemInit();
            }
            return Instance;
        }
    }
}
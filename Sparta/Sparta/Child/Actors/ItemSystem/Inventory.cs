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
    public class Inventory
    {
        public Inventory()
        {

        }

        public void Tick()
        {
            while (true)
            {
                Console.Clear();


                selectedIndex = selector.Select();
                switch (selectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        return;
                    default:
                        break;
                }
            }
        }
        protected Selector selector = new Selector();
        protected int selectedIndex = 0;
    }

}
using Sparta.Child;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sparta.SelectorSystem;
using Sparta.Child.Actors.MonsterSystem;

namespace Sparta.Parent
{
    class Field
    {
        public string Name { get; set; } = "";

        public Field()
        {

        }
        public Field(string name)
        {
            Name = name;
        }

        public virtual void Tick()
        {
            Console.Clear();
        }

        public void SpawnActor<ChildActor>() where ChildActor : Monster, new()
        {
            ChildActor actor = new ChildActor();
            actor.BeginPlay();
            Actors.Add(actor);
        }

        public virtual void BeginPlay()
        {

        }

        public virtual void FieldOpen()
        {

        }

        public virtual void EndPlay()
        {
            Actors.Clear();
        }

        public Field? ChangeField(string _fieldName)
        {
            return TextRpg.GetInst().FieldChange(_fieldName);
        }

        protected List<Monster> Actors = new List<Monster>();
        protected Selector selector = new Selector();
        protected int selectedIndex = 0;
    }
}

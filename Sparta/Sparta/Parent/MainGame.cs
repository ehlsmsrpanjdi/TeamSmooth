using Sparta.SelectorSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta.Parent
{
    class MainGame
    {
        protected MainGame()
        {

        }


        public void CreateField<ChildField>(string name) where ChildField : Field, new()
        {
            ChildField field = new ChildField();
            field.Name = name;
            fieldDictionary.Add(name, field);
        }

        public Field? FieldChange(string name)
        {
            if (!fieldDictionary.ContainsKey(name))
            {
                Console.WriteLine("존재하지 않는 레벨입니다.  아무키나 누르시오");
                Console.ReadKey();
                return null;
            }
            if (selectedField != null)
            {
                if (fieldDictionary.TryGetValue(name, out Field? field))
                {
                    Field PrevField = selectedField;
                    Field CurrentField = field;

                    PrevField.EndPlay();

                    CurrentField.BeginPlay();
                    selectedField = CurrentField;
                    return selectedField;
                }
            }
            else
            {
                if (fieldDictionary.TryGetValue(name, out Field? field))
                {
                    selectedField = field;
                    selectedField.BeginPlay();
                    return selectedField;
                }
            }
            return null;
        }

        virtual public void Start()
        {
            while (!IsEnd)
            {
                Tick();
            }
        }

        public void Tick()
        {
            if(selectedField != null)
            {
                selectedField.Tick();
            }
        }

        public void GameEnd()
        {
            IsEnd = true;
        }

        Field? selectedField = null;
        private bool IsEnd = false;

        Dictionary<string, Field> fieldDictionary = new Dictionary<string, Field>();

        protected Selector selector = new Selector();
        protected int selectedIndex = 0;
    }
}

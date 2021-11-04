using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    class AddRemoveCollection : Collectionss, IAddRemoveCollection
    {
        private List<string> list;
        public override IReadOnlyCollection<string> List { get => list.AsReadOnly(); }

        public AddRemoveCollection()
        {
            list = new List<string>();
        }

        public override int Add(string name)
        {
            list.Insert(0, name);
            return 0;
        }

        public string Remove()
        {
            string name = list[list.Count - 1];
            list.RemoveAt(list.Count-1);
            return name;
        }
    }
}

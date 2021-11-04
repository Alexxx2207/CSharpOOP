using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    class AddCollection : Collectionss, IAddCollection
    {
        private List<string> list;
        public AddCollection()
        {
            list = new List<string>();
        }
        public override IReadOnlyCollection<string> List { get => list.AsReadOnly(); }

        public override int Add(string name)
        {
            list.Add(name);
            return List.Count - 1;
        }
    }
}

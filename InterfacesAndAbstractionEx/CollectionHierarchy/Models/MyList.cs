using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    class MyList : Collectionss, IMyList
    {
        private List<string> list;

        public MyList()
        {
            list = new List<string>();
        }
        public int Used { get => list.Count; }

        public override IReadOnlyCollection<string> List => list.AsReadOnly();

        public override int Add(string name)
        {
            list.Insert(0, name);
            return 0;
        }

        public string Remove()
        {
            string name = list[0];
            list.RemoveAt(0);
            return name;
        }
    }
}

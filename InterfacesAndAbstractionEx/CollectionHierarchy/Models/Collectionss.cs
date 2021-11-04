using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public abstract class Collectionss
    {
        public abstract IReadOnlyCollection<string> List { get; }

        public abstract int Add(string name);
    }
}

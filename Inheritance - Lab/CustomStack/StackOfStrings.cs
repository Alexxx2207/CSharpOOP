using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }
        }
    }
}

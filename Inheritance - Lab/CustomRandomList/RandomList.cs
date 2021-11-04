using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        public string RandomString() 
        {
            Random rand = new Random();
            int randNum = rand.Next(0, this.Count);
            string word = this.GetRange(randNum, 1).ToString();
            this.RemoveAt(randNum);
            return word;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string fullname, int age)
        {
            Fullname = fullname;
            Age = age;
        }

        //[MyRequiredAttribute]
        [MyRequired]
        public string Fullname { get; set; }
        //[MyRangeAttribute]
        [MyRange(12,90)]
        public int Age { get; set; }
    }
}

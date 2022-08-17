using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerLibrary.Entities
{
    public abstract class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private readonly ICollection<Person> members;

        public Family()
        {
            this.members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            if (!this.members.Contains(member))
            {
                this.members.Add(member);
            }
        }

        public Person GetOldestMember()
            => this.members.OrderByDescending(m => m.Age).FirstOrDefault();
    }
}

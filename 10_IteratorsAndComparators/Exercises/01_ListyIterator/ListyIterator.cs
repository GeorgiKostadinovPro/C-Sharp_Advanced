using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private readonly List<T> list;
        private int currentIndex = 0;
        public ListyIterator(List<T> list)
        {
            this.list = list.ToList();
        }

        public bool Move()
        {
            if (this.currentIndex + 1 < this.list.Count)
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this.currentIndex + 1 < this.list.Count;
        }

        public void Print()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(list[currentIndex]);
        }
    }
}

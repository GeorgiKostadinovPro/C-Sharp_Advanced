using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;
        private int count;

        public CustomStack()
        {
            this.items = new T[InitialCapacity];
            this.count = 0;
        }

        public int Count => count;

        public void Push(T element)
        {
            if (this.Count == this.items.Length)
            {
                T[] copy = new T[this.items.Length * 2];

                for (int i = 0; i < items.Length; i++)
                {
                    copy[i] = this.items[i];
                }

                this.items = copy;
            }

            this.items[Count] = element;
            this.count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T element = this.items[Count - 1];
            this.items[Count - 1] = default(T);
            this.count--;

            return element;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Custom stack is empty!");
            }

            T element = this.items[Count - 1];
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

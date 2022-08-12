using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private LinkedListItem<T> first;
        private LinkedListItem<T> last;

        public int Count 
        {
            get 
            {
                int count = 0;

                LinkedListItem<T> currentItem = this.first;

                while (currentItem != null)
                {
                    count++;
                    currentItem = currentItem.Next;
                }

                return count;
            }
        }

        public void AddFirst(T element)
        {
            LinkedListItem<T> item = new LinkedListItem<T>(element);

            if (this.first == null)
            {
                this.first = item;
                this.last = item;
            }
            else 
            { 
                item.Next = this.first;
                this.first.Prev = item;
                this.first = item;
            }
        }

        public void AddLast(T element)
        {
            LinkedListItem<T> item = new LinkedListItem<T>(element);

            if (this.last == null)
            {
                this.first = item;
                this.last = item;
            }
            else
            {
                item.Prev = this.last;
                this.last.Next = item;
                this.last = item;
            }
        }

        public T RemoveFirst()
        {
            if (this.first == null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T itemToRemove = this.first.Value;

            if (this.first == this.last)
            {
                this.first = null;
                this.last = null;
            }
            else 
            {
                LinkedListItem<T> newFirst = this.first.Next;
                newFirst.Prev = null;
                this.first = newFirst;
            }

            return itemToRemove;
        }

        public T RemoveLast()
        {
            if (this.last == null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T itemToRemove = this.last.Value;

            if (this.first == this.last)
            {
                this.first = null;
                this.last = null;
            }
            else
            {
                LinkedListItem<T> newLast = this.last.Prev;
                newLast.Next = null;
                this.last = newLast;
            }

            return itemToRemove;
        }

        public bool Contains(T element)
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            LinkedListItem<T> currentItem = this.first;

            bool isFound = false;

            while (currentItem != null)
            {
                if (currentItem.Value.Equals(element))
                {
                    isFound = true;
                    break;
                }

                currentItem = currentItem.Next;
            }

            return isFound;
        }

        public void ForEach(Action<T> action)
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            LinkedListItem<T> currentItem = this.first;

            while (currentItem != null)
            {
                action(currentItem.Value);
                currentItem = currentItem.Next;
            }
        }

        public T[] ToArray()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T[] array = new T[this.Count];
            int index = 0;

            LinkedListItem<T> currentItem = this.first;
           
            while (currentItem != null)
            {
                array[index++] = currentItem.Value;
                currentItem = currentItem.Next;
            }

            return array;
        }
    }
}

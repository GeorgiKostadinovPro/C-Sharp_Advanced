using System;

namespace CustomStackAndQueue
{
    public class MyList<T>
    {
        private int capacity;
        private T[] data;

        public MyList()
            : this(4)
        {

        }

        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.data[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.data[index] = value;
            }
        }


        public void Add(T element)
        {
            CheckIfResizeIsNeeded();
            this.data[this.Count] = element;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);
            T result = this.data[index];
            for (int i = index + 1; i < this.Count; i++)
            {
                this.data[i - 1] = this.data[i];
            }

            this.Count--;
            return result;
        }

        public void Insert(int index, T element)
        {
            this.ValidateIndex(index);
            this.Count++;
            CheckIfResizeIsNeeded();
            this.ShiftRight(index);
            this.data[index] = element;

        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);
            T firstValue = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = firstValue;
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new T[this.capacity];
        }
        private void CheckIfResizeIsNeeded()
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.data[i] = this.data[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.data[i + 1] = this.data[i];
            }
        }
        private void ValidateIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return;
            }

            string message = this.Count == 0
                ? "This list is empty"
                : $"This list has {this.Count} elements and it's zero-based and you are trying to access {index} index which is not in the list";
            throw new ArgumentException($"Index out of range. {message}");
        }

        private void Resize() => this.data = ChangeArrayLength("*");
        private void Shrink() => this.data = ChangeArrayLength("/");
        private T[] ChangeArrayLength(string operation)
        {
            int currentOperation = operation == "*" ? this.data.Length * 2 : this.data.Length / 2;

            int newCapacity = currentOperation;
            T[] newData = new T[newCapacity];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            return newData;
        }
    }
}

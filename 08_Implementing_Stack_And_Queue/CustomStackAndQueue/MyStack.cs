using System;

namespace CustomStackAndQueue
{
    public class MyStack<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] data;

        public int Count { get; private set; }

        public MyStack()
        {
            this.Count = 0;
            this.data = new T[INITIAL_CAPACITY];
        }

        public void Push(T element)
        {
            if (this.Count == data.Length)
            {
                this.ResizeStack();
            }
            this.data[this.Count] = element;
            Count++;
        }

        public T Peek()
        {
            IsEmptyStack();
            T element = data[Count - 1];
            return element;
        }

        public T Pop()
        {
            IsEmptyStack();
            T element = data[this.Count - 1];
            data[this.Count - 1] = default(T);
            Count--;
            return element;
        }

        public void Clear()
        {
            this.Count = 0;
            this.data = new T[INITIAL_CAPACITY];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.data[i]);
            }
        }

        private void IsEmptyStack()
        {
            if (this.data.Length == 0)
            {
                throw new ArgumentException("The Stack is empty");
            }
        }

        private void ResizeStack()
        {
            T[] newData = new T[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }
    }
}

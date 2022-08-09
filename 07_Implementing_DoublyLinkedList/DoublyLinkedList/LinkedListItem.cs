namespace DoublyLinkedList
{
    public class LinkedListItem<T>
    {
        public LinkedListItem(T value)
        {
            this.Value = value;
        }

        public LinkedListItem<T> Next { get; set; }

        public LinkedListItem<T> Prev { get; set; }

        public T Value { get; private set; }
    }
}

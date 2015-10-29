namespace Problem_12.ADTQueue
{
    using System.Collections.Generic;

    public class ADTQueue<T>
    {
        public ADTQueue()
        {
            this.Items = new LinkedList<T>();
        }

        public LinkedList<T> Items { get; private set; }

        public int Count
        {
            get { return this.Items.Count; }

        }

        public void Enqueue(T item)
        {
            this.Items.AddLast(item);
        }

        public T Dequeue()
        {
            var result = Items.First.Value;
            this.Items.RemoveFirst();
            return result;
        }

        public T Peek()
        {
            return Items.First.Value;
        }

    }
}

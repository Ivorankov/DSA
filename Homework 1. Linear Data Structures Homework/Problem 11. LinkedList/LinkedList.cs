namespace Problem_11.LinkedList
{
    using System;

    public class LinkedList<T> 
    {
        private int size;

        private ListItem<T> firstElement;

        private ListItem<T> current;

        public LinkedList()
        {
            size = 0;
            firstElement = null;
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public void Add(T item)
        {
            size++;

            var node = new ListItem<T>(item);

            if (firstElement == null)
            {
                firstElement = node;
            }
            else
            {
                current.Next = node;
            }

            current = node;
        }

        public void ListNodes()
        {
            ListItem<T> tempNode = firstElement;

            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Value);
                tempNode = tempNode.Next;
            }
        }

        public ListItem<T> Retrieve(int position)
        {
            ListItem<T> tempNode = firstElement;
            ListItem<T> retNode = null;
            int count = 0;

            while (tempNode != null)
            {
                if (count == position - 1)
                {
                    retNode = tempNode;
                    break;
                }
                count++;
                tempNode = tempNode.Next;
            }

            return retNode;
        }

        public bool Delete(int index)
        {
            if (index == 1)
            {
                firstElement = null;
                current = null;
                return true;
            }

            if (index > 1 && index <= size)
            {
                ListItem<T> tempNode = firstElement;

                ListItem<T> lastNode = null;
                int count = 0;

                while (tempNode != null)
                {
                    if (count == index - 1)
                    {
                        lastNode.Next = tempNode.Next;
                        return true;
                    }
                    count++;

                    lastNode = tempNode;
                    tempNode = tempNode.Next;
                }
            }

            return false;
        }
    }
}

namespace Problem_11.LinkedList
{
   public class ListItem<T>
    {
       public ListItem(T item)
       {
           this.Value = item;
           this.Next = null;
       }  

        public T Value { get; set; }

        public ListItem<T> Next { get; set; }
    }
}

namespace BasicGame.LimitedList
{
    public class LimitedList<T>
    {
        private int capacity;
        private List<T> list;

        public int Count => list.Count;
        //{ 
        //    return list.Count;
        //}
        //{
        //    get { return list.Count; }
        //}

        public bool IsFull => capacity <= Count;

        public T this[int index] => list[index];

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(capacity, 2);
            list = new List<T>(this.capacity);
        }

        public bool Add(T item)
        {
            ArgumentNullException.ThrowIfNull(item, "item");

            if (IsFull) return false;
            list.Add(item); return true;

        }
    }
}
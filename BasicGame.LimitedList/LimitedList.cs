using System.Collections;

namespace BasicGame.LimitedList
{
    public class LimitedList<T> : IEnumerable<T> 
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
        //{
        //    get => list.ElementAt(index);
        //}
        //{
        //    get
        //    {
        //       return list[index];
        //    }
        //    set => list[index] = value;
        //}

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

        public bool Remove(T item) => list.Remove(item);

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                //....

                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
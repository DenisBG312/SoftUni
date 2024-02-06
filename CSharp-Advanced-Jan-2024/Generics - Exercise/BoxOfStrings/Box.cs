using System.Text;

namespace BoxOfStrings
{
    public class Box<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T item in items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString();
        }
    }
}

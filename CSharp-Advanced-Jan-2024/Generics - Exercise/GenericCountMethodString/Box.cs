namespace GenericCountMethodString
{
    public class Box<T> where T: IComparable<T>

    {
    private List<T> list;

    public Box()
    {
        list = new List<T>();
    }

    public void Add(T item)
    {
        list.Add(item);
    }

    public int Count(T itemToCompare)
    {
        int count = 0;
        foreach (var item in list)
        {
            if (item.CompareTo(itemToCompare) > 0)
            {
                count++;
            }
        }

        return count;
    }
    }
}

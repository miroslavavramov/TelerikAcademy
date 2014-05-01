using System;
using System.Text;

class GenericList<T>
    where T : IComparable
{
    private T[] list;

    public int Count
    {
        get; private set;
    }

    public int Capacity
    {
        get { return this.list.Length; }
    }
    
    public GenericList() : this(4)  //default capacity
    {
    }

    public GenericList(int capacity)
    {
        this.list = new T[capacity];
        this.Count = 0;
    }
    
    public void Add(T element)
    {
        if (this.Count == this.Capacity)
        {
            ExtendCapacity();
        }

        list[this.Count] = element;
        this.Count += 1;
    }

    public void RemoveAt(int index)
    {
        if (index >= this.Count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = index; i < this.Count; i++)
        {
            list[i] = list[i + 1];
        }

        this.Count -= 1;
    }

    public void Insert(int index, T element)
    {
        if (!(index >= 0 && index <= this.Count))
        {
            throw new IndexOutOfRangeException();
        }
        if (this.Capacity == this.Count)
        {
            ExtendCapacity();
        }

        for (int i = this.Count; i > index; i--)
        {
            list[i] = list[i - 1];
        }

        list[index] = element;
        this.Count += 1;
    }

    public void Clear()
    {
        list = new T[4];
        this.Count = 0;
    }

    public int Find(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (list[i].Equals(element))
            {
                return i;
            }
        }
        return -1;
    }

    public T GetAt(int index)
    {
        if (index > this.Count)
        {
            throw new IndexOutOfRangeException();
        }
        return list[index];
    }

    public T Min()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty List!");
        }

        T min = list[0];

        for (int i = 1; i < this.Count; i++)
        {
            if (min.CompareTo(list[i]) > 0)
            {
                min = list[i];
            }
        }

        return min;
    }

    public T Max()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Empty List!");
        }

        T max = list[0];

        for (int i = 1; i < this.Count; i++)
        {
            if (max.CompareTo(list[i]) < 0)
            {
                max = list[i];
            }
        }

        return max;
    }

    public override string ToString()
    {
        if (this.Count == 0)
        {
            return "Empty list";
        }

        var output = new StringBuilder("[ ");

        for (int i = 0; i < this.Count; i++)
        {
            output.Append(string.Format("{0}", list[i]));

            if (i != this.Count - 1)
            {
                output.Append(", ");
            }
        }

        return output.Append(" ]").ToString();
    }

    private void ExtendCapacity()
    {
        T[] extended = new T[this.Capacity * 2];

        for (int i = 0; i < this.Count; i++)
        {
            extended[i] = list[i];
        }

        list = extended;
    }
}
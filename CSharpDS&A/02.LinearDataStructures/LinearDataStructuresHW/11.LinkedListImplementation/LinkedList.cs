using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LinkedList<T> : IEnumerable<T>     //Doubly Linked List
    where T : IComparable
{
    public LinkedList()
    {
        this.Count = 0;
    }

    public ListItem<T> Head { get; private set; }
    public ListItem<T> Tail { get; private set; }
    public int Count { get; private set; }
    public bool Empty
    {
        get { return this.Count == 0; }
    }

    public void AddFirst(T value)
    {
        var newItem = new ListItem<T>(value);

        if (this.Empty)
        {
            this.Head = newItem;
            this.Tail = this.Head;
        }
        else
        {
            newItem.NextItem = this.Head;
            this.Head.PreviousItem = newItem;
            this.Head = newItem;
        }

        this.Count++;
    }

    public void Add(T value)
    {
        var newItem = new ListItem<T>(value);

        if (this.Empty)
        {
            this.Head = newItem;
            this.Tail = this.Head;
        }
        else
        {
            this.Tail.NextItem = newItem;
            newItem.PreviousItem = this.Tail;
            this.Tail = newItem;
        }

        this.Count++;
    }

    public void Remove(T value)
    {
        if (this.Head.Value.CompareTo(value) == 0)
        {
            this.Head = this.Head.NextItem;
            this.Count--;
        }
        else
        {
            var currentItem = this.Head.NextItem;

            while (currentItem != null)
            {
                if (currentItem.Value.CompareTo(value) == 0)
                {
                    currentItem.PreviousItem.NextItem = currentItem.NextItem;

                    if (currentItem.NextItem != null)
                    {
                        currentItem.NextItem.PreviousItem = currentItem.PreviousItem;
                    }

                    this.Count--;
                    break;
                }

                currentItem = currentItem.NextItem;
            }
        }
    }

    public void RemoveFirst()
    {
        if (this.Empty)
        {
            //throw new InvalidOperationException("Can't remove items from an empty list!");
        }
        else
        {
            this.Head = this.Head.NextItem;
            this.Head.PreviousItem = null;
            this.Count--;
        }
    }

    public void RemoveLast()
    {
        if (this.Empty)
        {
            //throw new InvalidOperationException("Can't remove items from an empty list!");
        }
        else
        {
            this.Tail = this.Tail.PreviousItem;
            this.Tail.NextItem = null;
            this.Count--;
        }
    }

    public override string ToString()
    {
        var output = new StringBuilder();

        foreach (var item in this)
        {
            output.AppendFormat("{0} <--> ", item);
        }

        return output.Append("null").ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var item = this.Head; item != null; item = item.NextItem)
        {
            yield return item.Value;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


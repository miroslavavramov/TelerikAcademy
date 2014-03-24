using System;
using System.Collections;
using System.Collections.Generic;

class Queue<T> : IEnumerable<T>
{
    private LinkedList<T> elements;

    public Queue()
    {
        this.elements = new LinkedList<T>();
    }

    public int Count 
    { 
        get { return this.elements.Count; } 
    }

    public void Enqueue(T item)
    {
        this.elements.AddLast(item);
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Can't take elements from an empty queue.");
        }
        else
        {
            var dequeued = this.elements.First.Value;

            this.elements.RemoveFirst();
            
            return dequeued;
        }
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Can't take elements from an empty queue.");
        }
        else
        {
            return this.elements.First.Value;
        }
    }

    public bool Contains(T value)
    {
        for (var item = this.elements.First; item != null; item = item.Next)
        {
            if (item.Value.Equals(value))
            {
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        this.elements.Clear();
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        for (var item = this.elements.First; item != null; item = item.Next)
        {
            yield return item.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


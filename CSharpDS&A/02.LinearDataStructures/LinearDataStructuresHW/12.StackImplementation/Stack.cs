using System;
using System.Collections;
using System.Collections.Generic;

class Stack<T> : IEnumerable<T>
{
    const int InitialCapacity = 4;

    private T[] elements;

    public Stack()
    {
        this.elements = new T[InitialCapacity];
        this.Count = 0;
    }

    public int Capacity
    { 
        get { return this.elements.Length; } 
    }

    public int Count { get; private set; }

    public void Push(T element) 
    {
        if (this.Count == this.Capacity)
        {
            this.ExpandCapacity();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count > 0)
        {
            var popped = this.elements[this.Count - 1];

            this.elements[this.Count - 1] = default(T);
            this.Count--;

            return popped;
        }
        else
        {
            throw new InvalidOperationException("Can not take elements from an empty stack.");
        }
    }

    public T Peek() 
    {
        if (this.Count > 0)
        {
            var peeked = this.elements[this.Count - 1];

            return peeked;
        }
        else
        {
            throw new InvalidOperationException("Can not take elements from an empty stack.");
        }
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        this.elements = new T[InitialCapacity];
        this.Count = 0;
    }

    private void ExpandCapacity()
    {
        var resized = new T[this.Capacity * 2];

        for (int i = 0; i < this.Capacity; i++)
        {
            resized[i] = elements[i];
        }

        this.elements = resized;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


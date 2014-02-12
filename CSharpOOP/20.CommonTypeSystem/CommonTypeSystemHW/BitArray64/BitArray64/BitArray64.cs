using System;
using System.Collections;
using System.Collections.Generic;

class BitArray64 
    : IEnumerable<int>
{
    private ulong Bits { get; set; }

    public BitArray64()
        : this(0)
    { 
    }

    public BitArray64(ulong bits)
    {
        this.Bits = bits;
    }

    public override bool Equals(object obj)
    {
        return this.Bits.Equals((ulong)(obj));
    }

    public override int GetHashCode()
    {
        return this.Bits.GetHashCode();
    }

    public override string ToString()
    {
        return Convert.ToString((long)this.Bits, 2);
    }

    public static bool operator ==(BitArray64 firstArr, BitArray64 secondArr)
    {
        return firstArr.Bits.Equals(secondArr.Bits);
    }

    public static bool operator != (BitArray64 firstArr, BitArray64 secondArr)
    {
        return !firstArr.Bits.Equals(secondArr.Bits);
    }

    public int this[int position]
    {
        get 
        {
            if (!(position >= 0 && position < 63))
            {
                throw new IndexOutOfRangeException();
            }
            return (int)(this.Bits >> position) & 1; 
        }
        set
        {
            if (!(position >= 0 && position < 63))
            {
                throw new IndexOutOfRangeException();
            }
            if (value == 1)
            {
                this.Bits = this.Bits | ((ulong)1 << position);
            }
            else if (value == 0)
            {
                this.Bits = this.Bits & (ulong)(~(1 << position));
            }
            else
            {
                throw new ArgumentOutOfRangeException("Bit value must be 0 or 1!");
            }
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < Convert.ToString((long)this.Bits, 2).Length; i++)
        {
            yield return this[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
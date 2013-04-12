using System;
using System.Collections;
using System.Collections.Generic;


class BitArray64 : IEnumerable<int>
{
    public ulong Number { get; set; }

    public BitArray64(ulong number)
    {
        this.Number = number;
    }

    public IEnumerator<int> GetEnumerator()
    {
        ulong reminder = Number;
        for (int i = 0; i < 64; i++)
        {
            int bit = Convert.ToInt32(reminder % 2);
            reminder = reminder / 2;
            yield return bit;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public static bool operator ==(BitArray64 first, BitArray64 second)
    {
        return BitArray64.Equals(first, second);
    }

    public static bool operator !=(BitArray64 first, BitArray64 second)
    {
        return !BitArray64.Equals(first, second);
    }

    public int this[int i]
    {
        get
        {
            if (i < 0||i > 63)
            {
                throw new IndexOutOfRangeException("Index should be in range 0 - 63");
            }
            int mask = 1 << i;
            int result = (int)(this.Number & (ulong)mask);
            return result >> i;
        }
    }


    public override int GetHashCode()
    {
        return this.Number.GetHashCode();
    }


    public override bool Equals(object obj)
    {
        BitArray64 value = (obj as BitArray64);
        if (value == null)
        {
            return false;
        }
        if (value.Number != this.Number)
        {
            return false;
        }
        return true;
    }
}
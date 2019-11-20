using System;

namespace Performance
{
    internal struct S : IComparable<S>
    {
        public int I;

        public int CompareTo(S other) => this.I.CompareTo(other.I);
    }
}

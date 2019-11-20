using System;

namespace Performance
{
    internal class C : IComparable<C>
    {
        public int I;

        public C(int i)
        {
            this.I = i;
        }

        public int CompareTo(C other) => this.I.CompareTo(other.I);
    }
}

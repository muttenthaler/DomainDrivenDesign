using System;
using System.Collections.Generic;
using System.Linq;

namespace Muttenthaler.DomainDrivenDesign
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public sealed override int GetHashCode()
        {
            HashCode hashCode = new();
            foreach (object equaliltyComponent in GetEqualityComponents())
            {
                hashCode.Add(equaliltyComponent);
            }
            return hashCode.ToHashCode();
        }

        public sealed override bool Equals(object obj)
        {
            return Equals(obj as ValueObject);
        }

        public bool Equals(ValueObject other)
        {
            return Equals(this, other);
        }

        public static bool operator ==(ValueObject x, ValueObject y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(ValueObject x, ValueObject y)
        {
            return !Equals(x, y);
        }

        private static bool Equals(ValueObject x, ValueObject y)
        {
            return BothAreNull(x, y) || BothAreObjectsAndEqual(x, y);
        }

        private static bool BothAreNull(ValueObject x, ValueObject y)
        {
            return x is null && y is null;
        }

        private static bool BothAreObjectsAndEqual(ValueObject x, ValueObject y)
        {
            return BothAreObjects(x, y) && SameType(x, y) && SameValues(x, y);
        }

        private static bool BothAreObjects(ValueObject x, ValueObject y)
        {
            return x is object && y is object;
        }

        private static bool SameType(ValueObject x, ValueObject y)
        {
            return x.GetType() == y.GetType();
        }

        private static bool SameValues(ValueObject x, ValueObject y)
        {
            return x.GetEqualityComponents().SequenceEqual(y.GetEqualityComponents());
        }
    }
}

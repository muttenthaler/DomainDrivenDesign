using System;
using System.Collections.Generic;
using Xunit;

namespace Muttenthaler.DomainDrivenDesign.Tests
{
    public class ValueObjectEqualityTests
    {
        [Fact]
        public void NullIsEqualToNull()
        {
            //Given
            ValueObject x = null;
            ValueObject y = null;

            //When

            //Then
            Assert.Equal(x, y);
            Assert.True(x == y);
            Assert.False(x != y);
        }

        [Fact]
        public void NonNullIsNotEqualToNull()
        {
            //Given
            ValueObject x = new ValueObjectA(1234);
            ValueObject y = null;

            //When

            //Then
            Assert.NotEqual(x, y);
            Assert.False(x == y);
            Assert.True(x != y);
        }

        [Fact]
        public void NullIsNotEqualToNonNull()
        {
            //Given
            ValueObject x = null;
            ValueObject y = new ValueObjectA(1234);

            //When

            //Then
            Assert.NotEqual(x, y);
            Assert.False(x == y);
            Assert.True(x != y);
        }

        [Fact]
        public void SameTypeAndSameValuesIsEqual()
        {
            //Given
            int someInteger = 1234;
            ValueObject x = new ValueObjectA(someInteger);
            ValueObject y = new ValueObjectA(someInteger);

            //When

            //Then
            Assert.Equal(x, y);
            Assert.True(x == y);
            Assert.False(x != y);
        }

        [Fact]
        public void SameTypeAndDifferentValuesIsNotEqual()
        {
            //Given
            ValueObject x = new ValueObjectA(1234);
            ValueObject y = new ValueObjectA(5678);

            //When

            //Then
            Assert.NotEqual(x, y);
            Assert.False(x == y);
            Assert.True(x != y);
        }

        [Fact]
        public void DifferentTypeIsNotEqual()
        {
            //Given
            int someInteger = 1234;
            ValueObject x = new ValueObjectA(someInteger);
            ValueObject y = new ValueObjectB(someInteger);

            //When

            //Then
            Assert.NotEqual(x, y);
            Assert.False(x == y);
            Assert.True(x != y);
        }

        [Fact]
        public void SuccessiveInvocationsReturnSameValue()
        {
            //Given
            int someInteger = 1234;
            ValueObject entity1 = new ValueObjectA(someInteger);
            ValueObject entity2 = new ValueObjectA(someInteger);
            bool[] results = new bool[10];

            //When
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = entity1.Equals(entity2);
            }

            //Then
            Assert.All(results, b => { if (b != results[0]) throw new Exception(); });
        }

        [Fact]
        public void EqualsIsReflexive()
        {
            //Given
            ValueObject x = new ValueObjectA(1234);

            //When

            //Then
            Assert.True(x.Equals(x));
        }

        [Fact]
        public void EqualsIsSymmetric()
        {
            //Given
            int someInteger = 1234;
            ValueObject x = new ValueObjectA(someInteger);
            ValueObject y = new ValueObjectA(someInteger);

            //When

            //Then
            Assert.Equal(x.Equals(y), y.Equals(x));
        }

        [Fact]
        public void EqualsIsTransitive()
        {
            //Given
            int someInteger = 1234;
            ValueObject x = new ValueObjectA(someInteger);
            ValueObject y = new ValueObjectA(someInteger);
            ValueObject z = new ValueObjectA(someInteger);

            //When

            //Then
            if (x.Equals(y) && y.Equals(z))
            {
                Assert.Equal(x, z);
            }
        }
    }

    internal class ValueObjectA : ValueObject
    {
        public int SomeInteger { get; private set; }

        public ValueObjectA(int someInteger)
        {
            SomeInteger = someInteger;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SomeInteger;
        }
    }

    internal class ValueObjectB : ValueObject
    {
        public int SomeInteger { get; private set; }

        public ValueObjectB(int someInteger)
        {
            SomeInteger = someInteger;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return SomeInteger;
        }
    }
}

using System;
using Xunit;

namespace Muttenthaler.DomainDrivenDesign.Tests
{
    public class EntityEqualityTests
    {
        [Fact]
        public void NullIsEqualToNull()
        {
            //Given
            Entity x = null;
            Entity y = null;

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
            Entity x = new EntityA(Guid.NewGuid());
            Entity y = null;

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
            Entity x = null;
            Entity y = new EntityA(Guid.NewGuid());

            //When

            //Then
            Assert.NotEqual(x, y);
            Assert.False(x == y);
            Assert.True(x != y);
        }

        [Fact]
        public void SameTypeAndSameIdIsEqual()
        {
            //Given
            Guid id = Guid.NewGuid();
            Entity x = new EntityA(id);
            Entity y = new EntityA(id);

            //When

            //Then
            Assert.Equal(x, y);
            Assert.True(x == y);
            Assert.False(x != y);
        }

        [Fact]
        public void SameTypeAndDifferentIdIsNotEqual()
        {
            //Given
            Entity x = new EntityA(Guid.NewGuid());
            Entity y = new EntityA(Guid.NewGuid());

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
            Guid id = Guid.NewGuid();
            Entity x = new EntityA(id);
            Entity y = new EntityB(id);

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
            Guid id = Guid.NewGuid();
            Entity entity1 = new EntityA(id);
            Entity entity2 = new EntityA(id);
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
            Entity x = new EntityA(Guid.NewGuid());

            //When

            //Then
            Assert.True(x.Equals(x));
        }

        [Fact]
        public void EqualsIsSymmetric()
        {
            //Given
            Guid id = Guid.NewGuid();
            Entity x = new EntityA(id);
            Entity y = new EntityA(id);

            //When

            //Then
            Assert.Equal(x.Equals(y), y.Equals(x));
        }

        [Fact]
        public void EqualsIsTransitive()
        {
            //Given
            Guid id = Guid.NewGuid();
            Entity x = new EntityA(id);
            Entity y = new EntityA(id);
            Entity z = new EntityA(id);

            //When

            //Then
            if (x.Equals(y) && y.Equals(z))
            {
                Assert.Equal(x, z);
            }
        }
    }

    internal class EntityA : Entity
    {
        public EntityA(Guid id)
        : base(id)
        {
        }
    }

    internal class EntityB : Entity
    {
        public EntityB(Guid id)
        : base(id)
        {
        }
    }
}

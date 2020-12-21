using System;
using System.Collections.Generic;

namespace Muttenthaler.DomainDrivenDesign
{
    // TODO: is it a good idea that Entity inherits from ValueObject?
    public abstract class Entity : ValueObject
    {
        public Guid Id { get; private set; }

        public Entity(Guid id)
        {
            Id = id;
        }

        protected sealed override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}

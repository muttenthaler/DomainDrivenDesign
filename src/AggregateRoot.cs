using System;

namespace Muttenthaler.DomainDrivenDesign
{
    public abstract class AggregateRoot : Entity
    {
        public AggregateRoot(Guid id)
        : base(id)
        {
        }
    }
}

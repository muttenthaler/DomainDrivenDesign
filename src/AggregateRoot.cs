using System;

namespace Muttenthaler.DomainDrivenDesign
{
    public abstract class AggregateRoot<TIdentifier> : Entity<TIdentifier>
    where TIdentifier : IEquatable<TIdentifier>
    {
        public AggregateRoot(TIdentifier id)
        : base(id)
        {
        }
    }
}

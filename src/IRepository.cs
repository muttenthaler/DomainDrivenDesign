using System;

namespace Muttenthaler.DomainDrivenDesign
{
    // TODO: method "SaveChanges" here?
    public interface IRepository<TAggregateRoot, TIdentifier>
    where TAggregateRoot : AggregateRoot<TIdentifier>
    where TIdentifier : IEquatable<TIdentifier>
    {
        void Add(TAggregateRoot aggregateRoot);
        void Remove(TAggregateRoot aggregateRoot);
        TAggregateRoot GetById(TIdentifier id);
    }
}

using System;

namespace Muttenthaler.DomainDrivenDesign
{
    // TODO: method "SaveChanges" here?
    public interface IRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
    {
        void Add(TAggregateRoot aggregateRoot);
        void Remove(TAggregateRoot aggregateRoot);
        TAggregateRoot GetById(Guid id);
    }
}

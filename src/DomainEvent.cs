using System;

namespace Muttenthaler.DomainDrivenDesign
{
    public abstract class DomainEvent
    {
        public DateTime Timestamp { get; private set; }

        protected DomainEvent()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}

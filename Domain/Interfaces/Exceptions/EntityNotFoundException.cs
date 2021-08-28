using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Domain.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string Entity { get; set; }
        public object Key { get; set; }
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message,
            Exception innerException) : base(message, innerException) { }

        public EntityNotFoundException(string entity, object key) =>
            (Entity, Key) = (entity, key);

        public override string ToString() => 
            $"{this.Entity}.{this.Key}: {this.Message}";
    }
}

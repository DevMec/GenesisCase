using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Entities
{
    public abstract class EntityBase : IEntity
    {
        protected EntityBase()
        {

        }
        public EntityBase(Guid? id, string name, string address)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (String.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            Id = id.HasValue ? id.Value : Guid.NewGuid();
            Name = name;
            Address = address;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    
    }
}

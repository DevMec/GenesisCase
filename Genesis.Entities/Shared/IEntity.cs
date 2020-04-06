using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genesis.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
    }
}
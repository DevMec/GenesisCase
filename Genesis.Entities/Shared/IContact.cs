using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genesis.Entities
{
    public interface IContact
    {
        ICollection<Company> CompanyList { get; set; }
    }
}
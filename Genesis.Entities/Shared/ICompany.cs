using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genesis.Entities
{
    public interface ICompany
    {
        List<string> SateliteAddressList { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Entities
{
    public class Contact: EntityBase, IContact
    {
        private Contact(): base()
        {
            CompanyList = new HashSet<Company>();
        }
        public Contact(Guid? id, string name, string address, string vat, bool isFreelancer = false)
            : base(id, name, address)
        {
            if (String.IsNullOrWhiteSpace(vat) && isFreelancer)
            {
                throw new ArgumentNullException(nameof(vat));
            }

            IsFreelancer = isFreelancer;
        }

        public void AddCompany(Company company)
        {
            if(company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            CompanyList.Add(company);
        }

        public void RemoveCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            CompanyList.Remove(company);
        }

        public virtual ICollection<Company> CompanyList { get; set; }

        public bool IsFreelancer { get; set; }

        private string _vat;

        public string VAT
        {
            get { return _vat; }
            set { 
                if(String.IsNullOrWhiteSpace(value) && IsFreelancer) 
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _vat = value;
            }
        }
    }
}

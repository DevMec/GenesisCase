using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genesis.Entities
{
    public class Company : EntityBase, ICompany
    {
        private Company(): base()
        {
            ContactList = new HashSet<Contact>();
        }
        public Company(Guid? id, string name, string address, string vat, List<string> sateliteAddressList)
            :base(id, name, address)
        {
            if (String.IsNullOrWhiteSpace(vat))
            {
                throw new ArgumentNullException(nameof(vat));
            }

            VAT = vat;
            Name = name;
            Address = address;
            SateliteAddressList = sateliteAddressList ?? new List<string>();
        }
        
        public List<string> SateliteAddressList { get; set; }
        public string VAT { get; set; }

        public virtual ICollection<Contact> ContactList { get; set; }

        public void AddContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            ContactList.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            ContactList.Remove(contact);
        }
    }
}
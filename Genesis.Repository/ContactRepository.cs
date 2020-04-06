using Genesis.Entities;
using Genesis.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Repository
{
    public class ContactRepository : EntityRepository<Contact>, IContactRepository
    {
        public ContactRepository() : base(new GenesisContext())
        {

        }
        public ContactRepository(GenesisContext context)
            : base(context)
        {

        }


        public override IEnumerable<Contact> GetAll()
        {
            var result = _context.Contacts.Include("CompanyList");
            return result;
        }

        public override Contact GetById(Guid id)
        {
            var result = _context.Contacts.Include("CompanyList").SingleOrDefault(x => x.Id == id);
            return result;
        }

        public override void Update(Contact item)
        {
            var contact = _context.Contacts.Find(item.Id);
            contact.Name = item.Name;
            contact.Address = item.Address;
            contact.IsFreelancer = item.IsFreelancer;
            contact.VAT = item.VAT;

            _context.SaveChanges();
        }

        public override Contact Create(Contact item)
        {
            Contact result;
            foreach (var cpny in item.CompanyList)
            {
                _context.Companies.Attach(cpny);
            }
            result = _context.Contacts.Add(item);
            _context.SaveChanges();
            return result;
        }
        
        public Contact AddCompany(Guid contactId, Guid companyId)
        {
            var contact = _context.Contacts.Include("CompanyList").SingleOrDefault(x => x.Id == contactId);
            var company = _context.Companies.Find(companyId);

            contact.CompanyList.Add(company);
            _context.SaveChanges();
            return contact;
        }

        public Contact RemoveCompany(Guid contactId, Guid companyId)
        {
            var contact = _context.Contacts.Include("CompanyList").SingleOrDefault(x => x.Id == contactId);
            var company = _context.Companies.Find(companyId);

            contact.CompanyList.Remove(company);
            _context.SaveChanges();
            return contact;
        }
    }
}

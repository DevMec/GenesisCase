using Genesis.Domain;
using Genesis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Repository
{
    public class CompanyRepository : EntityRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(): base(new GenesisContext())
        {

        }
        public CompanyRepository(GenesisContext context)
            :base(context)
        {

        }

        public override IEnumerable<Company> GetAll()
        {
            var result = _context.Companies.Include("ContactList");
            return result;
        }

        public override Company GetById(Guid id)
        {
            var result = _context.Companies.Include("ContactList").SingleOrDefault(x => x.Id == id);
            return result;
        }

        public override void Update(Company item)
        {
            var company = _context.Companies.Find(item.Id);
            company.Name = item.Name;
            company.Address = item.Address;
            company.VAT = item.VAT;

            _context.SaveChanges();
        }

        public override Company Create(Company item)
        {
            Company result;
            foreach (var cnt in item.ContactList)
            {
                _context.Contacts.Attach(cnt);
            }
            result = _context.Companies.Add(item);
            _context.SaveChanges();
            return result;
        }

        public Company AddContact(Guid companyId, Guid contactId)
        {
            var company = _context.Companies.Include("ContactList").SingleOrDefault(x => x.Id == companyId);
            var contact = _context.Contacts.Find(contactId);

            company.ContactList.Add(contact);
            _context.SaveChanges();
            return company;
        }

        public Company RemoveContact(Guid companyId, Guid contactId)
        {
            var company = _context.Companies.Include("ContactList").SingleOrDefault(x => x.Id == companyId);
            var contact = _context.Contacts.Find(contactId);

            company.ContactList.Remove(contact);
            _context.SaveChanges();
            return company;
        }
    }
}

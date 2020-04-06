using Genesis.Entities;
using System;
using System.Collections.Generic;

namespace Genesis.Domain
{
    public class ContactDomain : IContactDomain
    {
        private readonly IContactRepository _contactRepository;
        public ContactDomain(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public Contact Save(Contact item)
        {
            if(_contactRepository.GetById(item.Id) == null)
            {
                item = _contactRepository.Create(item);
            }
            else
            {
                _contactRepository.Update(item);
            }
            return item;
        }

        public void Delete(Guid id)
        {
            _contactRepository.Delete(id);
        }

        public void Delete(Contact item)
        {
            _contactRepository.Delete(item);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public Contact GetById(Guid id)
        {
            return _contactRepository.GetById(id);
        }

        public Contact AddCompany(Guid contactId, Guid companyId)
        {
            return _contactRepository.AddCompany(contactId, companyId);
        }

        public Contact RemoveCompany(Guid contactId, Guid companyId)
        {
            return _contactRepository.RemoveCompany(contactId, companyId);
        }
    }
}
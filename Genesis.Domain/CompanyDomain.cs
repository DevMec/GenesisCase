using Genesis.Entities;
using System;
using System.Collections.Generic;

namespace Genesis.Domain
{
    public class CompanyDomain : ICompanyDomain
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyDomain(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public Company Save(Company item)
        {
            if (_companyRepository.GetById(item.Id) == null)
            {
                item = _companyRepository.Create(item);
            }
            else
            {
                _companyRepository.Update(item);
            }
            return item;
        }

        public void Delete(Guid id)
        {
            _companyRepository.Delete(id);
        }

        public void Delete(Company item)
        {
            _companyRepository.Delete(item);
        }

        public IEnumerable<Company> GetAll()
        {
            return _companyRepository.GetAll();
        }

        public Company GetById(Guid id)
        {
            return _companyRepository.GetById(id);
        }

        public Company AddContact(Guid companyId, Guid contactId)
        {
            return _companyRepository.AddContact(companyId, contactId);
        }

        public Company RemoveContact(Guid companyId, Guid contactId)
        {
            return _companyRepository.RemoveContact(companyId, contactId);
        }
    }
}
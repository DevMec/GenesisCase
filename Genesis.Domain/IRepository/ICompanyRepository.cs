using Genesis.Entities;
using System;
using System.Collections.Generic;

namespace Genesis.Domain
{
    public interface ICompanyRepository
    {
        Company GetById(Guid Id);
        IEnumerable<Company> GetAll();
        Company Create(Company item);
        void Update(Company item);
        void Delete(Guid Id);
        void Delete(Company item);
        Company AddContact(Guid companyId, Guid contactId);
        Company RemoveContact(Guid companyId, Guid contactId);
    }
}
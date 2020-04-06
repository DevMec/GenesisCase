using Genesis.Entities;
using System;
using System.Collections.Generic;

namespace Genesis.Domain
{
    public interface ICompanyDomain
    {
        Company GetById(Guid Id);
        IEnumerable<Company> GetAll();
        Company Save(Company item);
        void Delete(Guid Id);
        void Delete(Company item);
        Company AddContact(Guid companyId, Guid contactId);
        Company RemoveContact(Guid companyId, Guid contactId);
    }
}
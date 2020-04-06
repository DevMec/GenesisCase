using Genesis.Entities;
using System;
using System.Collections.Generic;

namespace Genesis.Domain
{
    public interface IContactRepository
    {
        Contact GetById(Guid Id);
        IEnumerable<Contact> GetAll();
        Contact Create(Contact item);
        void Update(Contact item);
        void Delete(Guid Id);
        void Delete(Contact item);

        Contact AddCompany(Guid contactId, Guid companyId);
        Contact RemoveCompany(Guid contactId, Guid companyId);
    }
}
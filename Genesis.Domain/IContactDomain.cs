using Genesis.Entities;
using System;
using System.Collections.Generic;

namespace Genesis
{
    public interface IContactDomain
    {
        Contact GetById(Guid Id);
        IEnumerable<Contact> GetAll();
        Contact Save(Contact item);
        Contact AddCompany(Guid contactId, Guid companyId);
        Contact RemoveCompany(Guid contactId, Guid companyId);
        void Delete(Guid Id);
        void Delete(Contact item);
    }
}
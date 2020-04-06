using Genesis.Entities;
using System;
using System.Collections.Generic;

namespace Genesis.Repository
{
    public interface IEntityRepository<TEntity> where TEntity: class, IEntity
    {
        TEntity GetById(Guid Id);
        IEnumerable<TEntity> GetAll();
        TEntity Create(TEntity item);
        void Update(TEntity item);
        void Delete(Guid Id);
        void Delete(TEntity item);

    }
}

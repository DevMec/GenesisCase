using Genesis.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Repository
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        internal GenesisContext _context;
        internal DbSet<TEntity> dbSet;

        public EntityRepository()
        {
            _context = new GenesisContext();
        }
        public EntityRepository(GenesisContext context)
        {
            _context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual TEntity Create(TEntity item)
        {
            TEntity result;
            result = dbSet.Add(item);
            _context.SaveChanges();
            return result;
        }

        public void Delete(Guid Id)
        {
            TEntity entityToDelete = dbSet.Find(Id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            _context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var result = dbSet.ToList();
            return result;
        }

        public virtual TEntity GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(TEntity item)
        {
            dbSet.Add(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

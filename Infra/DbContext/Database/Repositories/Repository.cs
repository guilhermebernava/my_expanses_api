using Database.Data;
using Database.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ExpanseContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ExpanseContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public bool Add(TEntity obj, bool bCommit)
        {
            DbSet.Add(obj);
            return !bCommit || SaveChanges() > 0;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll() => DbSet.AsNoTracking();

        public IQueryable<TEntity> GetAllBy(Func<TEntity, bool> exp) => DbSet.Where(exp).AsQueryable().AsNoTracking();

        public TEntity GetById(Guid id) => DbSet.Find(id);

        public bool ForceDelete(Guid id, bool bCommit)
        {
            DbSet.Remove(DbSet.Find(id));
            return !bCommit || SaveChanges() > 0;
        }

        public bool SoftDelete(TEntity obj)
        {
            var entity = obj as Entity;
            if (entity == null) return false;
            entity.Delete();
            DbSet.Update(obj);
            return SaveChanges() > 0;
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public bool Update(TEntity obj, bool bCommit)
        {
            var entity = obj as Entity;
            if (entity == null) return false;
            entity.Update();
            DbSet.Update(obj);
            return !bCommit || SaveChanges() > 0;
        }

    }
}


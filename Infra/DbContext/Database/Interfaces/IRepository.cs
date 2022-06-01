namespace Database.Interfaces
{
	public interface IRepository<TRepository> : IDisposable where TRepository : class
	{
        bool Add(TRepository obj, bool bCommit = true);
        bool Update(TRepository obj, bool bCommit = true);
        bool ForceDelete(Guid id, bool bCommit = true);
        bool SoftDelete(TRepository obj);
        TRepository GetById(Guid id);
        IQueryable<TRepository> GetAll();
        IQueryable<TRepository> GetAllBy(Func<TRepository, bool> exp);
        int SaveChanges();
    }
}


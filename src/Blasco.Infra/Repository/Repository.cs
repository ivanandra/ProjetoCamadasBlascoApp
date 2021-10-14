using Blasco.Business.Core.Data;
using Blasco.Business.Core.Models;
using Blasco.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blasco.Infra.Repository
{

    //Alguns métodos são virtuais para que na hora de implementar no repositório espcializado, você poder modificá-los//
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        public readonly BlascoDbContext Db;
        public readonly DbSet<TEntity> DbSet;

        protected Repository()
        {
            Db = new BlascoDbContext();
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        //asNotracking desabilita o tracker do entity framework, dando performance, observa a entidade para ver se mudou, se vai persistir ela//
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }


        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }
        public virtual async Task Remover(Guid id)
        {
            Db.Entry(new TEntity { Id = id}).State = EntityState.Deleted;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        //Db? significa que só chamará o método se tiver uma instância definida//
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}

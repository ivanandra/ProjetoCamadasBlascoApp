using Blasco.Business.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Business.Core.Data
{
    interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);

        Task<TEntity> ObterPorId(Guid id);

        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);

        Task Remover(Guid id);
        //Retorna uma coleção de Entidades, método buscar, Recebe expressão em cima da entidade que está trabalhando, através do predicado busca a expressão desejada//
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        //Retorna um int referente as linhas afetadas após persistir no banco//
        Task<int> SaveChanges();

    }
}

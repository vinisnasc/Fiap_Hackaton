using Fiap_Hackaton.Health_Med.Domain.Entities;
using System.Linq.Expressions;

namespace Fiap_Hackaton.Health_Med.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task<List<T>> SelecionarTudo();
        Task<T> Buscar(Expression<Func<T, bool>> predicate);
        Task<List<T>> BuscarVarios(Expression<Func<T, bool>> predicate);
        Task<T> SelecionarPorId(Guid id);

        Task IncluirAsync(T entity);
        Task Alterar(T entity);
        void Remover(T entity);

        Task<int> SaveChanges();
    }
}
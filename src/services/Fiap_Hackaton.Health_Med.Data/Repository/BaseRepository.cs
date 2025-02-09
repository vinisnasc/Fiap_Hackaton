using Fiap_Hackaton.Health_Med.Data.Contexto;
using Fiap_Hackaton.Health_Med.Domain.Entities;
using Fiap_Hackaton.Health_Med.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fiap_Hackaton.Health_Med.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContexto _context;
        protected DbSet<T> _dbSet;

        public BaseRepository(AppDbContexto context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public virtual async Task Alterar(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Buscar(Expression<Func<T, bool>> predicate)
            => await _dbSet.FirstOrDefaultAsync(predicate);

        public virtual async Task<List<T>> BuscarVarios(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        public virtual async Task IncluirAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Remover(T entity) => _dbSet.Remove(entity);

        public virtual async Task<T> SelecionarPorId(Guid id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public virtual async Task<List<T>> SelecionarTudo()
            => await _dbSet.ToListAsync();

        public void Dispose() => _context.Dispose();

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();
    }
}
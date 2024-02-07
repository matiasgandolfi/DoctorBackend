using DoctorApp.Context;
using DoctorApp.Interfaces.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DoctorApp.Repositorio
{
    public class Repositorio<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly ContextDb _db;
        private DbSet<T> _dbSet;

        public Repositorio(ContextDb db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }



        /***********************************Metodos****************************************/



        public async Task Agregar(T entidad)
        {
            await _dbSet.AddAsync(entidad);
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = _dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (incluirPropiedades != null)
            {
                foreach (var ip in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(ip);
                }
            }
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = _dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (incluirPropiedades != null)
            {
                foreach (var ip in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(ip);
                }
            }
            if(orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public void Remover(T entidad)
        {
            _dbSet.Remove(entidad);
        }
    }
}

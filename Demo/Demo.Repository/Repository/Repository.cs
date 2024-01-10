using System.Linq.Expressions;
using Demo.Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Dbset;
        protected readonly LocalDbContext DbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public Repository(LocalDbContext context)
        {
            DbContext = context;
            Dbset = context.Set<T>();
        }

        /// <summary>
        /// Function use to get Object flow Id
        /// </summary>
        /// <param name="id">Primary key of Table current</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return Dbset.Find(id);
        }

        /// <summary>
        /// Get one object asyn by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsyncById(int id)
        {
            return await Dbset.FindAsync(id);
        }
        /// <summary>
        /// Get All list Object
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Function use in the case Query have condition
        /// </summary>
        /// <param name="filter">Condition of query</param>
        /// <returns></returns>
        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return Dbset.Where(filter);
        }

        /// <summary>
        /// Function use to Update Object 
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        public T Update(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Dbset.Attach(entity);
            }

            dbEntityEntry.State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// Update multiple objects 
        /// </summary>
        /// <param name="listItem"></param>
        /// <returns></returns>
        public List<T> UpdateMulti(List<T> listItem)
        {
            foreach (var item in listItem)
            {
                Update(item);
            }
            return listItem;
        }

        /// <summary>
        /// Function use to Insert Object 
        /// </summary>
        /// <param name="entity">Object is targer Update</param>
        /// <returns></returns>
        public T Insert(T entity)
        {
            Dbset.Add(entity);

            return entity;
        }

        /// <summary>
        /// Query get one object and include another tables relationship
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public List<T> InsertMulti(List<T> entity)
        {
            foreach (var item in entity)
            {
                Dbset.Add(item);
            }
            return entity;
        }

        /// <summary>
        /// Function use to Remove Object in Database
        /// </summary>
        /// <param name="id">Id is identity</param>
        /// <returns></returns>
        public bool Delete(dynamic id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }

            Dbset.Remove(entity);
            return true;
        }

        /// <summary>
        /// Deletes the mullti.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool DeleteMulti(List<T> entity)
        {
            try
            {
                Dbset.RemoveRange(entity);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Query get one object and include another tables relationship
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = Dbset.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            query = query.Where(expression);
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Query by condition and include multiple tables relationship
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public List<T> FindAll(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = Dbset.AsQueryable();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            return query.ToList();
        }
    }
}

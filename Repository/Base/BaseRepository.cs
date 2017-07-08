using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repository.Base
{
    public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity:class
    {
        BlogDB db = new BlogDB();

        DbSet<TEntity> _dbSet;

        public BaseRepository()
        {
            _dbSet = db.Set<TEntity>();
        }

        public void Add(TEntity model)
        {
            _dbSet.Add(model);
        }

        public void Delete(TEntity model, bool isadded)
        {
            if (!isadded)
            {
                _dbSet.Attach(model);
            }
            _dbSet.Remove(model);
        }

        public void Edit(TEntity model, string[] propertys)
        {
            if(model == null)
            {
                throw new Exception("model is empty");
            }

            if(propertys.Any() == false)
            {
                throw new Exception("the property is empty");
            }

            DbEntityEntry entry = db.Entry(model);
            entry.State = EntityState.Unchanged;

            foreach(var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }

            db.Configuration.ValidateOnSaveEnabled = false;
        }

        public void Edit(TEntity model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public List<TEntity> QueryByPage<TKey>(int pageIndex, int pageSize, out int rowcount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool IsQueryOrderBy)
        {
            rowcount = _dbSet.Count(predicate);
            if (IsQueryOrderBy)
            {
                return _dbSet.Where(predicate).OrderBy(keySelector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                return _dbSet.Where(predicate).OrderByDescending(keySelector).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableName)
        {
            if(tableName == null && tableName.Any() == false)
            {
                throw new Exception("table name is empty");
            }

            DbQuery<TEntity> query = _dbSet;

            foreach (var table in tableName)
            {
                query = query.Include(table);
            }

            return query.Where(predicate).ToList();
        }

        public List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool IsQueryOrderBy)
        {
            if (IsQueryOrderBy)
            {
                return _dbSet.Where(predicate).OrderBy(keySelector).ToList();
            }

            return _dbSet.Where(predicate).OrderByDescending(keySelector).ToList();
        }

        public List<TEntity> QuerySingle(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public List<TResult> RunProc<TResult>(string sql, params object[] pamrs)
        {
            return db.Database.SqlQuery<TResult>(sql, pamrs).ToList();
        }

        public int SaveChange()
        {
            return db.SaveChanges();
        }
    }
}

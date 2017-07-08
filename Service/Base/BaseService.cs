using Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public IBaseRepository<TEntity> baseDal;

        public void Add(TEntity model)
        {
            baseDal.Add(model);
        }

        public void Delete(TEntity model, bool isadded)
        {
            baseDal.Delete(model, isadded);
        }

        public void Edit(TEntity model, string[] propertys)
        {
            baseDal.Edit(model, propertys);
        }

        public void Edit(TEntity model)
        {
            baseDal.Edit(model);
        }

        public List<TEntity> QueryByPage<TKey>(int pageIndex, int pageSize, out int rowcount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool IsQueryOrderBy)
        {
            return baseDal.QueryByPage(pageIndex, pageSize, out rowcount, predicate, keySelector, IsQueryOrderBy);
        }

        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tablename)
        {
            return baseDal.QueryJoin(predicate, tablename);
        }

        public List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool IsQueryOrderBy)
        {
            return baseDal.QueryOrderBy(predicate, keySelector, IsQueryOrderBy);
        }

        public List<TEntity> QuerySingle(Expression<Func<TEntity, bool>> predicate)
        {
            return baseDal.QuerySingle(predicate);
        }

        public List<TResult> RunProc<TResult>(string sql, params object[] pamrs)
        {
            return baseDal.RunProc<TResult>(sql, pamrs);
        }

        public int SaveChanges()
        {
            return baseDal.SaveChange();
        }
    }
}

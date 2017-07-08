using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        List<TEntity> QuerySingle(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableName);

        List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool IsQueryOrderBy);

        List<TEntity> QueryByPage<TKey>(int pageIndex, int pageSize, out int rowcount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool IsQueryOrderBy);

        void Edit(TEntity model, string[] propertys);
        void Edit(TEntity model);
        void Delete(TEntity model, bool isadded);
        void Add(TEntity model);
        int SaveChange();

        List<TResult> RunProc<TResult>(string sql, params object[] pamrs);
    }
}

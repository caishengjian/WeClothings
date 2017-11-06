using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.IRepository
{
  public  interface IBaseRepository<TEntity> where TEntity:class,new()
    {
        //接口中定义方法
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        bool SaveChanges();
        //单个查询
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wherelambda">输入一个lambda表达式</param> 表达式类型他会带上查询条件一并生成sql语句，将查询结果返回提高查询效率
        TEntity SelectEntity(Func<TEntity,bool> wherelambda);
        //集合查询    带有条件的集合要加where
        IEnumerable<TEntity> SelectEntitys(Func<TEntity, bool> wherelambda);
        //带有分页查询的集合 pagesize,pageIndex
        IEnumerable<TEntity> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
        Expression<Func<TEntity, type>> OrderByLambda, Expression<Func<TEntity, bool>> wherelambda);
    }
    public class a
    {
        public void b()
        {
            List<object> list = new List<object>();
        }
    }
}

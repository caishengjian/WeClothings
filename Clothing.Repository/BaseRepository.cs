using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Clothing.IRepository;//
using Clothing.Model;//
using System.Data.Entity;//
namespace Clothing.Repository
{
    //DAL层实现IDAL接口层
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        //1.上下文对象  new用工厂模式代替
        private readonly Model1 dbcontext = DbContextFactory.CreateDbContext();
        //2.设置实体集Dbset
        public DbSet<TEntity> dbSet;
        public BaseRepository()
        {
            dbSet = dbcontext.Set<TEntity>();//构造一个实体集
        }
        public void Delete(TEntity entity)
        {
            //删除实体先查再删
            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, type>> OrderByLambda, Expression<Func<TEntity, bool>> WhereLambda)
        {
            var result = dbSet.Where(WhereLambda);
            result = isAsc ? dbSet.OrderBy(OrderByLambda) : result.OrderByDescending(OrderByLambda);
            result = result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return result.ToList();
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public TEntity SelectEntity(Func<TEntity, bool> wherelambda)
        {
            return dbSet.FirstOrDefault(wherelambda);
        }

        public IEnumerable<TEntity> SelectEntitys(Func<TEntity, bool> wherelambda)
        {
            return dbSet.Where(wherelambda);
        }

        public void Update(TEntity entity)
        {
            //查询要更新的实体  覆盖原有的
            dbSet.Attach(entity);
            //修改状态
            dbcontext.Entry(entity).State = EntityState.Modified;
        }

        public bool SaveChanges()
        {
           return dbcontext.SaveChanges() > 0;
        }
    }
}

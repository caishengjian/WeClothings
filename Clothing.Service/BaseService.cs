using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Clothing.IService;//
using Clothing.IRepository;//

namespace Clothing.Service
{
    //BLL 不能直接实例化DAL 依赖于IDAL
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        //声明一个IDAL的对象
        private IBaseRepository<TEntity> _ibaseRepository;
        //写构造函数传参数
        public BaseService(IBaseRepository<TEntity> ibaseRepository)
        {
            this._ibaseRepository = ibaseRepository;
        }
        public bool Add(TEntity entity)
        {
            _ibaseRepository.Insert(entity);
            return _ibaseRepository.SaveChanges();
        }

        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
            return _ibaseRepository.SelectEntity(whereLambda);
        }

        public IEnumerable<TEntity> GetEntityes(Func<TEntity, bool> whereLambda)
        {
            return _ibaseRepository.SelectEntitys(whereLambda);
        }

        public IEnumerable<TEntity> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, type>> OrderByLambda, Expression<Func<TEntity, bool>> WhereLambda)
        {
            return _ibaseRepository.GetModelsByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }

        public bool Modify(TEntity entity)
        {
            _ibaseRepository.Update(entity);
            return _ibaseRepository.SaveChanges();
        }

        public bool Remove(TEntity entity)
        {
            _ibaseRepository.Delete(entity);
            return _ibaseRepository.SaveChanges();
        }
     
    }
}

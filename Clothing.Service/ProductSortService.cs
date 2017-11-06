using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothing.Model;
using Clothing.IService;
using Clothing.IRepository;

namespace Clothing.Service
{
    public class ProductSortService : BaseService<ProductSort>, IProductSortService
    {
        public ProductSortService(IBaseRepository<ProductSort> ibaseRepository) : base(ibaseRepository)
        {
        }
    }
}

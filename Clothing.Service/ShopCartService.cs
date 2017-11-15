using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothing.IRepository;
using Clothing.IService;
using Clothing.Model;

namespace Clothing.Service
{
    public class ShopCartService : BaseService<ShopCart>, IShopCartService
    {
        public ShopCartService(IBaseRepository<ShopCart> ibaseRepository) : base(ibaseRepository)
        {
        }
    }
}

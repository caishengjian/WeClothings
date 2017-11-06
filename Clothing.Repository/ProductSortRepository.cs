using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothing.Model;
using Clothing.IRepository;

namespace Clothing.Repository
{
   public class ProductSortRepository:BaseRepository<ProductSort>,IProductSortRepository
    {
    }
}

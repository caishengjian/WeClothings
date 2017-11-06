using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothing.Model;
namespace Clothing.IRepository
{
    public interface IBannerRepository:IBaseRepository<Banner>
    {
        //通过数据库查询Banner表中的数据       
    }
}

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
    public class NoticeService : BaseService<Notice>, INoticeService
    {
        public NoticeService(IBaseRepository<Notice> ibaseRepository) : base(ibaseRepository)
        {
        }
    }
}

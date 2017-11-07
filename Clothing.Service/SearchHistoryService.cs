using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothing.IRepository;
using Clothing.IService;//
using Clothing.Model;//

namespace Clothing.Service
{
    public class SearchHistoryService : BaseService<SearchHistory>, ISearchHistoryService
    {
        public SearchHistoryService(IBaseRepository<SearchHistory> ibaseRepository) : base(ibaseRepository)
        {

        }
    }
}

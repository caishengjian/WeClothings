﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothing.IRepository;//
using Clothing.IService;//
using Clothing.Model;//
namespace Clothing.Service
{
    public class BannerService : BaseService<Banner>, IBannerService
    {
        public BannerService(IBaseRepository<Banner> ibaseRepository) : base(ibaseRepository)
        {

        }
    }
}

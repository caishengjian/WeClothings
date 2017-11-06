using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using Clothing.Model;//


namespace Clothing.Repository
{
    //工厂类获取上下文对象  
  public  class DbContextFactory
    {
       public static Model1 CreateDbContext()
        {
            Model1 DBContext = CallContext.GetData("DbContext") as Model1;
            if (DBContext == null)//此处需要下载EF程序集然后引用system.Data.Entity
            {
                DBContext = new Model1();
                CallContext.SetData("DbContext", DBContext);
            }
            return DBContext;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.StoredProcedure
{
    public class SPAccount
    {
        public static string Access_UserRole_Get = "usp_Access_UserRole_Get @p0";
        public static string UserRole_get = "usp_UserRole_get @p0";
        
    }
}

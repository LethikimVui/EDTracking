using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.StoredProcedure
{
    public class SPCommon
    {
        public static string Access_Role_get = "usp_Access_Role_get";
        public static string Master_Customer_Get = "usp_Master_Customer_Get @p0";
        public static string PartNumber_get = "usp_PartNumber_get";
        public static string WorkWeek_get = "usp_WorkWeek_get";
    }
}

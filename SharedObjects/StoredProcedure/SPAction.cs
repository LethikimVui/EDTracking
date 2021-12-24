using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.StoredProcedure
{
    public class SPAction
    {
        public static string Action_get = "usp_Action_get @p0";
        public static string Action_insert_single = "usp_Action_insert_single @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15";

        public static string Pending_get = "usp_Pending_get";
        public static string Pending_action = "usp_Pending_action @p0,@p1,@p2,@p3";

    }
}

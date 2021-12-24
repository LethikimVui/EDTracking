using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class PendingViewModel
    {
       
        public int PendingId { get; set; }
        public int ActionCode { get; set; }
        public string Remark { get; set; }
        public string UpdatedBy { get; set; }
    }
}

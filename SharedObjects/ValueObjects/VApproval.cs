using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VApproval
    {
        public int ApprovalId { get; set; }
        public string Ntlogin { get; set; }//
        //public string ApprovalEmail { get; set; }
        //public string ApprovalName { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        //public string CustName { get; set; }
        public int? CustId { get; set; }//
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VPending
    {
        
        public int PendingId { get; set; }
        public int ActionId { get; set; }
        public string CustName { get; set; }
        public string Pn { get; set; }
        public int? Qty { get; set; }
        public double? Percentage { get; set; }
        public byte? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Wwyy { get; set; }
        public string FailureMode { get; set; }
        public string RootCause { get; set; }
        public string ContainmentAction { get; set; }
        public string CorrectiveandPreventiveAction { get; set; }
        public string PartsCosignedOrTurnkey { get; set; }
        public string Fano { get; set; }
        public string SqelatestStatus { get; set; }
        public string Mfrfaresult { get; set; }
        public string Fianeeded { get; set; }
        public string Fiano { get; set; }
        public string ResponsiblePerson { get; set; }
       
    }
}

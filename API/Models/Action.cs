using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class Action
    {
        public int ActionId { get; set; }
        public string CustName { get; set; }
        public string Pn { get; set; }
        public int? Qty { get; set; }
        public double? Percentage { get; set; }
        public string Wwyy { get; set; }
        public string FailureMode { get; set; }
        public string RootCause { get; set; }
        public string PartsCosignedOrTurnkey { get; set; }
        public string Fano { get; set; }
        public string SqelatestStatus { get; set; }
        public string Mfrfaresult { get; set; }
        public string Fianeeded { get; set; }
        public string Fiano { get; set; }
        public string ResponsiblePerson { get; set; }
        public string ApprovedBy { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }
        public byte? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}

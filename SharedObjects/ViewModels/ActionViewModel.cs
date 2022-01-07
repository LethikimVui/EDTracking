using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class ActionViewModel
    {
        public string Wwyy { get; set; }
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string Pn { get; set; }
        public int ActionId { get; set; }
        public int ActionCode { get; set; }
        public string FailureMode { get; set; }
        public string ContainmentAction { get; set; }
        public string CorrectiveandPreventiveAction { get; set; }
        public string RootCause { get; set; }
        public string PartsCosignedOrTurnkey { get; set; }
        public string Fano { get; set; }
        public string SqelatestStatus { get; set; }
        public string Mfrfaresult { get; set; }
        public int Fianeeded { get; set; }
        public string Fiano { get; set; }
        public string ResponsiblePerson { get; set; }
        public string ApprovedBy { get; set; }
        public string Remark { get; set; }
        public string UpdatedBy { get; set; }
        public string DateCode { get; set; }
        public string WeeklyStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VAction_Export
    {
        public string WorkWeek { get; set; }
        public string WorkCell { get; set; }
        public string PartNumber { get; set; }
        public string DateCode { get; set; }
        public int? Quantity { get; set; }
        public string FailureMode { get; set; }
        public string RootCause { get; set; }
        public string ContainmentAction { get; set; }
        public string CorrectiveandPreventiveAction { get; set; }
        public string PartsCosignedOrTurnkey { get; set; }
        public string Fano { get; set; }
        public string Mfrfaresult { get; set; }
        public string Fianeeded { get; set; }
        public string Fiano { get; set; }
        public string ResponsiblePerson { get; set; }
        public string WeeklyStatus { get; set; }
        public  string Status { get; set; }
        public string Remark { get; set; }
        public int? Aging { get; set; }
    }
}

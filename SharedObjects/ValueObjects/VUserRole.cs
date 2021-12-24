using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VUserRole
    {
        public int UserRoleId { get; set; } //
        public string Ntlogin { get; set; }//
        //public string UserName { get; set; }//
        public byte RoleId { get; set; }//
        public byte PlantId { get; set; }//
        public byte CustId { get; set; }//
        public byte? IsActive { get; set; }//
        public string CreatedBy { get; set; }//
        public DateTime? CreationDate { get; set; }//
        public string UpdatedBy { get; set; }//
        public DateTime? UpdateDate { get; set; }//
        //public string Plant { get; set; }
        //public string CustName { get; set; }
        public string RoleName { get; set; }//
        //public string UserEmail { get; set; }
    }
}

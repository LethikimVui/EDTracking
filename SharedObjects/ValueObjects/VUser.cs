using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VUser
    {
        //public int UserRoleId { get; set; } //
        public string Ntlogin { get; set; }//
        public string UserName { get; set; }//
        public string UserEmail { get; set; }//
        //public Byte PlantId { get; set; }               
        public Byte? CustId { get; set; }//
        //public string CustName { get; set; }
        public Byte? RoleId { get; set; }//
        public string RoleName { get; set; }//
        //public Byte IsActive { get; set; }//
        //public DateTime? CreationDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime? UpdateDate { get; set; }
        //public string UpdatedBy { get; set; }
    }
}

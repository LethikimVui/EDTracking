using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class AccessUserRole
    {
        public int UserRoleId { get; set; }
        public string Ntlogin { get; set; }
        public string UserName { get; set; }
        public byte? RoleId { get; set; }
        public byte? PlantId { get; set; }
        public byte? CustId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public byte? IsActive { get; set; }
        public string UserEmail { get; set; }
    }
}

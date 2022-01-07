using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base()
        {

        }

        public ApplicationDbContext()
        {
        }

        //Scaffold-DbContext "Data Source=VNHCMC0SQL81;Initial Catalog=EDTracking;User Id=EDTracking_User;Password=EDTracking!@#123;MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer -Tables "Action" -OutputDir Models2

        public virtual DbSet<MasterApproval> MasterApproval { get; set; }
        public virtual DbSet<AccessUserRole> AccessUserRole { get; set; }
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbQuery<VAction> VAction { get; set; }
        public virtual DbQuery<VUser> VUser { get; set; }
        public virtual DbQuery<VPending> VPending { get; set; }
        public virtual DbQuery<VRole> VRole { get; set; }
        public virtual DbQuery<VUserRole> VUserRole { get; set; }
        public virtual DbQuery<VApproval> VApproval { get; set; }
        public virtual DbQuery<VCustomer> VCustomer { get; set; }
        public virtual DbQuery<VPartNumber> VPartNumber { get; set; }
        public virtual DbQuery<VWorkWeek> VWorkWeek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=VNHCMC0SQL81;Initial Catalog=TE_HCS;User Id=TE_HCS_USER;Password=Zxcvbnm123!@;MultipleActiveResultSets=true;");
                optionsBuilder.UseSqlServer("Data Source=VNHCMC0SQL81;Initial Catalog=EDTracking;User Id=EDTracking_User;Password=EDTracking!@#123;MultipleActiveResultSets=true;");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Action>(entity =>
            {
                entity.Property(e => e.ActionId).HasColumnName("actionId");

                entity.Property(e => e.ApprovedBy).HasColumnName("approvedBy");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustName)
                    .HasColumnName("custName")
                    .HasMaxLength(100);

                entity.Property(e => e.FailureMode)
                    .HasColumnName("failureMode")
                    .IsUnicode(false);

                entity.Property(e => e.Fano).HasColumnName("FANo");

                entity.Property(e => e.Fianeeded).HasColumnName("FIAneeded");

                entity.Property(e => e.Fiano).HasColumnName("FIANo");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Mfrfaresult).HasColumnName("MFRFAResult");

                entity.Property(e => e.PartsCosignedOrTurnkey).HasColumnName("partsCosignedOrTurnkey");

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.Pn)
                    .HasColumnName("PN")
                    .HasMaxLength(100);

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Remark).HasColumnName("remark");

                entity.Property(e => e.ResponsiblePerson).HasColumnName("responsiblePerson");

                entity.Property(e => e.RootCause).HasColumnName("rootCause");

                entity.Property(e => e.SqelatestStatus).HasColumnName("SQELatestStatus");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wwyy)
                    .HasColumnName("wwyy")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<MasterApproval>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);

                entity.ToTable("Master_Approval");

                entity.Property(e => e.UserRoleId).HasColumnName("userRoleId");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustId).HasColumnName("custID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Ntlogin)
                    .HasColumnName("NTLogin")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PlantId).HasColumnName("plantID");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<AccessUserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);

                entity.ToTable("Access_UserRole");

                entity.Property(e => e.UserRoleId).HasColumnName("userRoleId");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustId).HasColumnName("custID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Ntlogin)
                    .HasColumnName("NTLogin")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PlantId).HasColumnName("plantID");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updatedBy")
                    .HasMaxLength(30)
                    .IsUnicode(false);
               
            });

        }


    }
}

using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedObjects.Common;
using SharedObjects.StoredProcedure;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("Access_Role_get")]
        [Obsolete]
        public async Task<List<VRole>> Role_get()
        {
            var results = await context.Query<VRole>().AsNoTracking().FromSql(SPAdmin.Access_Role_get).ToListAsync();
            return results;
        }
        [HttpGet("Access_UserRole_get")]
        [Obsolete]
        public async Task<List<VUserRole>> UserRole_get()
        {
            var results = await context.Query<VUserRole>().AsNoTracking().FromSql(SPAdmin.Access_UserRole_get).ToListAsync();
            return results;
        }

        [HttpPost("Access_UserRole_insert")]
        [Obsolete]
        public async Task<IActionResult> Access_UserRole_insert(UserRoleViewModel model)
        {
            try
            {
                if (!context.AccessUserRole.Where(x => (x.Ntlogin == model.Ntlogin) && (x.CustId == model.CustId) && (x.RoleId == model.RoleId) && (x.IsActive == 1)).ToList().Any())
                {
                    await context.Database.ExecuteSqlCommandAsync(SPAdmin.Access_UserRole_insert, model.Ntlogin, model.RoleId, model.PlantId, model.CustId, model.CreatedBy);
                    return Ok(new ResponseResult(200, "User Added Successfully"));
                }
                else
                {
                    return Conflict(new ResponseResult(400, "User already existing"));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult(400, ex.Message));
            }
        }

        [HttpPost("Access_UserRole_delete")]
        [Obsolete]
        public async Task<IActionResult> Access_UserRole_delete(UserRoleViewModel model)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPAdmin.Access_UserRole_delete, model.UserRoleId, model.UpdatedBy);
                return Ok(new ResponseResult(200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult(400, ex.Message));
            }
        }
        [HttpGet("Master_Approval_get")]
        [Obsolete()]
        public async Task<List<VApproval>> Master_Approval_get()
        {
            var results = await context.Query<VApproval>().AsNoTracking().FromSql(SPAdmin.Master_Approval_get).ToListAsync();
            return results;
        }
        [HttpPost("Master_Approval_insert")]
        [Obsolete]
        public async Task<IActionResult> Master_Approval_insert(UserRoleViewModel model)
        {
            try
            {
                if (!context.MasterApproval.Where(x => (x.Ntlogin == model.Ntlogin) && (x.CustId == model.CustId) && (x.IsActive == 1)).ToList().Any())
                {
                    await context.Database.ExecuteSqlCommandAsync(SPAdmin.Master_Approval_insert, model.Ntlogin, model.CustId, model.CreatedBy);
                    return Ok(new ResponseResult(200, "User Added Successfully"));
                }
                else
                {
                    return Conflict(new ResponseResult(400, "User already existing"));
                }
                //await context.Database.ExecuteSqlCommandAsync(SPAdmin.Approval_add, model.Ntlogin, model.UserName, model.UserEmail, model.CustId, model.CreatedBy);
                //return Ok(new ResponseResult(200, "User Added Successfully"));                
            }

            catch (Exception ex)
            {
                return BadRequest(new ResponseResult(400, ex.Message));
            }
        }
        [HttpPost("Master_Approval_delete")]
        [Obsolete]
        public async Task<IActionResult> Master_Approval_delete(UserRoleViewModel model)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPAdmin.Master_Approval_delete, model.OwnerId, model.UpdatedBy);
                return Ok(new ResponseResult(200));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult(400, ex.Message));
            }

        }
    }
}

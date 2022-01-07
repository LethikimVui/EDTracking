using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SharedObjects.Extensions;

namespace Web.Controllers
{
    [Authorize(Roles = "System Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly ICommonService commonService;

        public AdminController(IAdminService adminService, ICommonService commonService)
        {
            this.adminService = adminService;
            this.commonService = commonService;
        }
        bool IsValidCredential(string userName, string password)
        {
            bool valid = false;
            using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
            {
                valid = context.ValidateCredentials(userName, password, ContextOptions.Negotiate);
                //var userPrincipal = UserPrincipal.FindByIdentity(context, userName);
                //var t = userPrincipal.EmailAddress;

            }
            return valid;
        }

        public string GetDisplayNameFromSamAccountName(string samAccountName)
        {
            using (var principalContext = new PrincipalContext(ContextType.Domain))
            {
                var userPrincipal = UserPrincipal.FindByIdentity(principalContext, samAccountName);
                if (userPrincipal != null)
                {
                    return userPrincipal.DisplayName;

                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<IActionResult> Get()
        {
            var NtLogin = User.GetSpecificClaim("Ntlogin");
            var userRoles = await adminService.Access_UserRole_get();
            ViewData["roles"] = await adminService.Access_Role_get();
            ViewData["customers"] = await commonService.Master_Customer_Get(NtLogin);
            return View(userRoles);
        }

        public async Task<IActionResult> Access_UserRole_insert([FromBody] UserRoleViewModel model)
        {

            var result = await adminService.Access_UserRole_insert(model);
            return Json(new { results = result });
        } 
        public async Task<IActionResult> Access_UserRole_update([FromBody] UserRoleViewModel model)
        {

            var result = await adminService.Access_UserRole_update(model);
            return Json(new { results = result });
        }
        public async Task<IActionResult> Access_UserRole_delete([FromBody] UserRoleViewModel model)
        {
            var result = await adminService.Access_UserRole_delete(model);
            return Json(new { results = result });
        }
        public async Task<IActionResult> Access_UserRole_Get_By_Id(int id)
        {
            var result = await adminService.Access_UserRole_Get_By_Id(id);
            return Json(new { results = result });
        }
        public async Task<IActionResult> Approval()
        {
            var NtLogin = User.GetSpecificClaim("Ntlogin");
            var approval = await adminService.Master_Approval_get();
            ViewData["roles"] = await adminService.Access_Role_get();
            ViewData["customers"] = await commonService.Master_Customer_Get(NtLogin);
            return View(approval);
        }
        public async Task<IActionResult> Master_Approval_Get_By_Id(int id)
        {
            var results = await adminService.Master_Approval_Get_By_Id(id);
            return Json(new { results = results });
        }
        public async Task<IActionResult> Master_Approval_insert([FromBody] UserRoleViewModel model)
        {
            var result = await adminService.Master_Approval_insert(model);
            return Json(new { results = result });
        }
        public async Task<IActionResult> Master_Approval_update([FromBody] UserRoleViewModel model)
        {
            var result = await adminService.Master_Approval_update(model);
            return Json(new { results = result });
        }
        public async Task<IActionResult> Master_Approval_delete([FromBody] UserRoleViewModel model)
        {
            var result = await adminService.Master_Approval_delete(model);
            return Json(new { results = result });
        }
    }
}

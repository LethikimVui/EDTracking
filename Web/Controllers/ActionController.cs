using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using SharedObjects.Extensions;

namespace Web.Controllers
{
    [Authorize]
    public class ActionController : Controller
    {
        private readonly IActionService actionService;
        private readonly IAdminService adminService;
        private readonly ICommonService commonService;

        public ActionController(IActionService actionService, IAdminService adminService, ICommonService commonService)
        {
            this.actionService = actionService;
            this.adminService = adminService;
            this.commonService = commonService;
        }

        public async Task<IActionResult> Get()
        {
            var NtLogin = User.GetSpecificClaim("Ntlogin");
            ViewData["customers"] = await commonService.Master_Customer_Get(NtLogin);
            //ViewData["partNumbers"] = await commonService.PartNumber_get();
            //ViewData["ww"] = await commonService.WorkWeek_get();
            //var results = await actionService.Get(0);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Get_partial([FromBody] ActionViewModel model)
        {
            var result = await actionService.Action_get_mul(model);
            return PartialView(result);
        }
        [HttpPost]
        public async Task<IActionResult> Action_export([FromBody] ActionViewModel model)
        {
            var results = await actionService.Action_export(model);
            return Json(new { result = results });
        }
        [HttpPost]
        public async Task<IActionResult> GetById(int Id)
        {
            var results = await actionService.Get(Id);
            return Json(new { results = results });
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ActionViewModel model)
        {
            if (model.ActionCode == 2)
            {
                SentEmail(model.ActionId, model.CustName, model.Pn, model.Wwyy);
            }
            var result = await actionService.Insert(model);
            return Json(new { results = result });
        }
        [HttpPost]
        public async Task<IActionResult> Acknowledge([FromBody] ActionViewModel model)
        {
            var result = await actionService.Acknowledge(model);
            return Json(new { results = result });
        }

        async void SentEmail(int actionID, string custName, string partNumber, string ww)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient("corimc04.corp.JABIL.ORG");
            message.From = new MailAddress("EDMS@Jabil.com");

            var UserEmail = User.GetSpecificClaim("UserEmail");
            message.CC.Add(new MailAddress(UserEmail));

            var approval = await adminService.Master_Approval_Get_By_actionId(actionID);
            string body = string.Empty;
            if (approval.Any())
            {
                foreach (var item in approval)
                {
                    message.To.Add(new MailAddress(item.UserEmail));
                }
            }
            else
            {
                body += "<p>Missing approval configuration. Please contact Admin.</p>";
            }
            //message.CC.Add(new MailAddress("vui_le@jabil.com"));            
            body += "<p>Hi,</p>";
            body += "<p>There is an item pending for your review and approval. Please access to this link to proceed: http://vnhcmm0teapp02/edtracking/ </p>";
            body += "<p>Regards!</p>";
            body += "<p>********************</p>";
            body += "<p>This is Auto Email, please do not reply!</p>";
            message.Subject = "[" + ww + "-" + custName + "] " + "Pending item: " + partNumber;
            message.Body = body;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}

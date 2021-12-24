using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize("Approval Owner")]
    public class PendingController : Controller
    {
        private readonly IPendingService pendingService;

        public PendingController(IPendingService pendingService)
        {
            this.pendingService = pendingService;
        }
        public async Task<IActionResult> Get()
        {
            var results = await pendingService.Get();
            return View(results);
        }
        [HttpPost]
        public async Task<IActionResult> Action([FromBody] PendingViewModel model)
        {
            //SentEmail(model.CustName, model.Pn, model.Wwyy);

            var result = await pendingService.Action(model);
            return Json(new { results = result });
        }

        void SentEmail(string custName, string partNumber, string ww)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient("corimc04.corp.JABIL.ORG");
            message.From = new MailAddress("EDTracking@Jabil.com");
            message.To.Add(new MailAddress("vui_le@jabil.com"));
            string body = string.Empty;
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

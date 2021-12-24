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
    [Authorize]
    public class ActionController : Controller
    {
        private readonly IActionService actionService;

        public ActionController(IActionService actionService)
        {
            this.actionService = actionService;
        }
        public async Task<IActionResult> Get()
        {
            var results = await actionService.Get(0);
            return View(results);
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
                SentEmail(model.CustName, model.Pn, model.Wwyy);
            }
            var result = await actionService.Insert(model);
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
            message.Subject = "["+ww +"-"+custName+"] " + "Pending item: "+ partNumber;

            message.Body = body;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}

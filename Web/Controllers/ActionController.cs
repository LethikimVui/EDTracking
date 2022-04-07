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
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers
{
    [Authorize]
    public class ActionController : Controller
    {
        private readonly IActionService actionService;
        private readonly IAdminService adminService;
        private readonly ICommonService commonService;
        private readonly IConfiguration configuration;

        public ActionController(IActionService actionService, IAdminService adminService, ICommonService commonService, IConfiguration configuration)
        {
            this.actionService = actionService;
            this.adminService = adminService;
            this.commonService = commonService;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Get()
        {
            var NtLogin = User.GetSpecificClaim("Ntlogin");
            ViewData["customers"] = await commonService.Master_Customer_Get(NtLogin);
            ViewData["status"] = await commonService.Master_Status_get();
            //ViewData["ww"] = await commonService.WorkWeek_get();
            //var results = await actionService.Get(0);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Get_partial([FromBody] ActionViewModel model)
        {
            var result = await actionService.Action_get(model);
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
        public async Task<IActionResult> Action_get([FromBody] ActionViewModel model)
        {
            var results = await actionService.Action_get(model);
            return Json(new { results = results });
        }
        //[HttpPost]
        //public async Task<IActionResult> Insert([FromBody] ActionViewModel model)
        //{
        //    if (model.ActionCode == 2)
        //    {
        //        SentEmail(model);
        //    }
        //    var result = await actionService.Action_update(model);
        //    return Json(new { results = result });
        //}
        [HttpPost]
        public async Task<IActionResult> Action_update([FromBody] ActionViewModel model)
        {
            if (model.ActionCode == 2)
            {
                SentEmail(model);
            }
            var result = await actionService.Action_update(model);
            return Json(new { results = result });
        }
        [HttpPost]
        public async Task<IActionResult> Acknowledge([FromBody] ActionViewModel model)
        {
            string response = "";
            if (model.ActionCode == 4)
            {

                response = "Acknowledged";
            }
            else if (model.ActionCode == 5)
            {
                response = "Closed";
            }
            SentConfirmEmail(model, response);
            var result = await actionService.Acknowledge(model);
            return Json(new { results = result });
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files, string date)
        {
            //var uploadFolder = $"{webHostEnvironment.WebRootPath}/media/attachment";
            string uploadFolder = @"\\" + configuration["Server"] + @"\EDMS\Attachment";
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file.FileName);//get filename
                var newfileName = fileName.Split('.')[0] + "_" + date + "." + fileName.Split('.')[1];

                var fullFilePath = Path.Combine(uploadFolder, newfileName);
                try
                {
                    using (var stream = new FileStream(fullFilePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }

            }
            return Ok(0);
        }
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            //var path = $"{webHostEnvironment.WebRootPath}/media/attachment/" + fileName;
            string path = @"\\" + configuration["Server"] + @"\EDMS\Attachment\" + fileName;

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        #region Sent Email
        async void SentEmail(ActionViewModel model)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient("corimc04.corp.JABIL.ORG");
            message.From = new MailAddress(configuration["SystemEmail"]);

            var approval = await adminService.Master_Approval_Get_By_actionId(model.ActionId);
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


            //var UserEmail = User.GetSpecificClaim("UserEmail");
            message.CC.Add(new MailAddress(model.UpdatedEmail));
            var configureEmail = configuration["Email:Cc"].Split(';');
            foreach (var email in configureEmail)
            {
                if (email != "")
                {
                    message.CC.Add(new MailAddress(email));
                }
            }

            body += "<p>THIS IS TESTING EMAIL, PLEASE IGNORE</p>";
            body += "<p>Hi,</p>";

            body += "<p>There is an item pending for your review and approval. Please access to this link to proceed: http://vnhcmm0teapp02/edtracking/ </p>";
            body += "<p>Regards!</p>";
            body += "<p>********************</p>";
            body += "<p>This is Auto Email, please do not reply!</p>";
            message.Subject = "[Testing][" + model.Wwyy + "-" + model.CustName + "] " + "Pending item: " + model.Pn;
            message.Body = body;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
        #endregion

        #region Sent Confirm Email
        private async void SentConfirmEmail([FromBody] ActionViewModel model, string response = null)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient("corimc04.corp.JABIL.ORG");
            message.From = new MailAddress(configuration["SystemEmail"]);
            string body = string.Empty;
            var approval = await adminService.Access_UserRole_Get_By_ActionId(model.ActionId);

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
            body += "<div style='border - top:3px solid #22BCE5'>Hi,</div>";

            if (response == "Acknowledged")
            {
                body += "<p>The item has been acknowledged and re-open to update the status. Please access <a href='http://vnhcmm0teapp02/edtracking/'>here</a> to get detail</p>";
            }
            else
                body += "<p>The item is closed. You may access <a href='http://vnhcmm0teapp02/edtracking/'>here</a> to get detail</p>";
            body += " <p>This is automatic email, please do not reply</p>    Thanks";

            message.CC.Add(new MailAddress(model.UpdatedEmail));
            var configureEmail = configuration["Email:Cc"].Split(';');
            foreach (var email in configureEmail)
            {
                if (email != "")
                {
                    message.CC.Add(new MailAddress(email));
                }
            }
            message.Subject = "[Testing][" + model.Wwyy + "-" + model.CustName + "] " + model.Pn + " Has Been " + response;
            message.Body = body;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class CommonController : Controller
    {
        private readonly ICommonService commonService;

        public CommonController(ICommonService commonService)
        {
            this.commonService = commonService;
        }
        public async Task<IActionResult> WorkWeek_get(int custId)
        {
            var yyww = await commonService.WorkWeek_get(custId);
            return Json(new { result = yyww });
        }   public async Task<IActionResult> PartNumber_get(int custId)
        {
            var partNumber = await commonService.PartNumber_get(custId);
            return Json(new { result = partNumber });
        }
    }
}

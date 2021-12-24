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
    public class PendingController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PendingController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("get")]
        [Obsolete()]
        public async Task<List<VPending>> Get()
        {
            var results = await context.Query<VPending>().AsNoTracking().FromSql(SPAction.Pending_get).ToListAsync();
            return results;
        }
        [HttpPost("Action")]
        [Obsolete]
        public async Task<IActionResult> Pending_action([FromBody] PendingViewModel model)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPAction.Pending_action, model.ActionCode, model.PendingId, model.Remark, model.UpdatedBy);
                return Ok(new ResponseResult(200));
            }
            catch (Exception)
            {
                return BadRequest(new ResponseResult(400, "Save failed"));
            }

        }

    }
}

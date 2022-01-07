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
    public class ActionController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ActionController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("get/{Id}")]
        [Obsolete()]
        public async Task<List<VAction>> Get(int Id)
        {
            var results = await context.Query<VAction>().AsNoTracking().FromSql(SPAction.Action_get, Id).ToListAsync();
            return results;
        } 
        [HttpPost("Action_get_mul")]
        [Obsolete()]
        public async Task<List<VAction>> Action_get_mul([FromBody] ActionViewModel model)
        {
            var results = await context.Query<VAction>().AsNoTracking().FromSql(SPAction.Action_get_mul, model.CustId, model.Wwyy, model.Pn).ToListAsync();
            return results;
        }
        [HttpPost("Insert")]
        [Obsolete]
        public async Task<IActionResult> Action_insert([FromBody] ActionViewModel model)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPAction.Action_insert_single, model.ActionId, model.ActionCode, model.DateCode, model.FailureMode, model.RootCause, model.ContainmentAction, model.CorrectiveandPreventiveAction, model.PartsCosignedOrTurnkey, model.Fano, model.SqelatestStatus, model.Mfrfaresult, model.Fianeeded, model.Fiano, model.ResponsiblePerson, model.Remark, model.WeeklyStatus, model.UpdatedBy);
                return Ok(new ResponseResult(200));
            }
            catch (Exception)
            {
                return BadRequest(new ResponseResult(400, "Save failed"));
            }

        }
        [HttpPost("Acknowledge")]
        [Obsolete]
        public async Task<IActionResult> Action_acknowledge([FromBody] ActionViewModel model)
        {
            try
            {
                await context.Database.ExecuteSqlCommandAsync(SPAction.Action_acknowledge, model.ActionId, model.ActionCode, model.Remark, model.UpdatedBy);
                return Ok(new ResponseResult(200));
            }
            catch (Exception)
            {
                return BadRequest(new ResponseResult(400, "Save failed"));
            }

        }



    }
}

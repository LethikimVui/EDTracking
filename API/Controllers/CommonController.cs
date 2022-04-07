using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedObjects.StoredProcedure;
using SharedObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CommonController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("Access_Role_get")]
        [Obsolete]
        public async Task<List<VRole>> Access_Role_get()
        {
            var results = await context.Query<VRole>().AsNoTracking().FromSql(SPCommon.Access_Role_get).ToListAsync();
            return results;
        }
        [HttpGet("Master_Status_get")]
        [Obsolete]
        public async Task<List<VStatus>> Master_Status_get()
        {
            var results = await context.Query<VStatus>().AsNoTracking().FromSql(SPCommon.Master_Status_get).ToListAsync();
            return results;
        }
        [HttpGet("PartNumber_get/{custId}")]
        [Obsolete]
        public async Task<List<VPartNumber>> PartNumber_get(int custId)
        {
            var results = await context.Query<VPartNumber>().AsNoTracking().FromSql(SPCommon.PartNumber_get, custId).ToListAsync();
            return results;
        }   
        [HttpGet("WorkWeek_get/{custId}")]
        [Obsolete]
        public async Task<List<VWorkWeek>> WorkWeek_get(int custId)
        {
            var results = await context.Query<VWorkWeek>().AsNoTracking().FromSql(SPCommon.WorkWeek_get, custId).ToListAsync();
            return results;
        }   
        [HttpGet("Master_Customer_Get/{NTLogin}")]
        [Obsolete]
        public async Task<List<VCustomer>> Master_Customer_Get(string NTLogin)
        {
            var results = await context.Query<VCustomer>().AsNoTracking().FromSql(SPCommon.Master_Customer_Get, NTLogin).ToListAsync();
            return results;
        }
    }
}

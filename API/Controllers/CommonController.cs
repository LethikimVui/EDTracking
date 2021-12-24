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
    }
}

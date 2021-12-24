using Newtonsoft.Json;
using Services.Interfaces;
using SharedObjects.Common;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CommonService : BaseService, ICommonService
    {
        public async Task<List<VRole>> Access_Role_get()
        {
            List<VRole> userRoles = new List<VRole>();
            using (var response = await httpClient.GetAsync("api/Common/Access_Role_get"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                userRoles = JsonConvert.DeserializeObject<List<VRole>>(apiResponse);
            }
            return userRoles;
        }
     
    }
}

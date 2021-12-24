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
    public class PendingService : BaseService, IPendingService
    {
        public async Task<ResponseResult> Action(PendingViewModel model)
        {
            ResponseResult result = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/Pending/action", content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return result;
        }

        public async Task<List<VPending>> Get()
        {
            var results = new List<VPending>();
            using (var response = await httpClient.GetAsync("api/Pending/Get"))
            {
                var content = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<List<VPending>>(content);
            }
            return results;
        }
    }
}

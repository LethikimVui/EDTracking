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
    public class ActionService : BaseService, IActionService
    {
        public async Task<List<VAction>> Get(int Id)
        {
            var results = new List<VAction>();
            using (var response = await httpClient.GetAsync("api/Action/Get/"+ Id))
            {
                var content = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<List<VAction>>(content);
            }
            return results;
        }

        public async Task<ResponseResult> Insert(ActionViewModel model)
        {
            ResponseResult result = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/action/Insert", content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return result;
        }
    }
}

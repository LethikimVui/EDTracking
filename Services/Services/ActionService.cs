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
        public async Task<ResponseResult> Acknowledge(ActionViewModel model)
        {
            ResponseResult result = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/action/Acknowledge", content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return result;
        }

        public async Task<List<VAction>> Action_get_mul(ActionViewModel model)
        {
            var results = new List<VAction>();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/Action/Action_get_mul/" , content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<List<VAction>>(apiResponse);
            }
            return results;
        }  public async Task<List<VAction_Export>> Action_export(ActionViewModel model)
        {
            var results = new List<VAction_Export>();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/Action/Action_export/", content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<List<VAction_Export>>(apiResponse);
            }
            return results;
        }

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

        public async Task<ResponseResult> Action_update(ActionViewModel model)
        {
            ResponseResult result = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/action/Action_update", content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return result;
        }

        public async Task<List<VAction>> Action_get(ActionViewModel model)
        {
            var results = new List<VAction>();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/Action/Action_get/", content))
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject<List<VAction>>(apiResponse);
            }
            return results;
        }
    }
}

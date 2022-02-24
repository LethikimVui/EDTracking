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
        public async Task<List<VPartNumber>> PartNumber_get(int custId)
        {
            List<VPartNumber> partNumber = new List<VPartNumber>();
            using (var response = await httpClient.GetAsync("api/Common/PartNumber_get/"+ custId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                partNumber = JsonConvert.DeserializeObject<List<VPartNumber>>(apiResponse);
            }
            return partNumber;
        }
        public async Task<List<VWorkWeek>> WorkWeek_get(int custId)
        {
            List<VWorkWeek> ww = new List<VWorkWeek>();
            using (var response = await httpClient.GetAsync("api/Common/WorkWeek_get/" + custId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ww = JsonConvert.DeserializeObject<List<VWorkWeek>>(apiResponse);
            }
            return ww;
        }
        public async Task<List<VCustomer>> Master_Customer_Get(string NtLogin)
        {
            List<VCustomer> customer = new List<VCustomer>();
            using (var response = await httpClient.GetAsync("api/Common/Master_Customer_Get/" + NtLogin))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                customer = JsonConvert.DeserializeObject<List<VCustomer>>(apiResponse);
            }
            return customer;
        }
     
    }
}

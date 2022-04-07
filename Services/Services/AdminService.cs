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
    public class AdminService : BaseService, IAdminService
    {
        public async Task<List<VRole>> Access_Role_get()
        {
            List<VRole> roles = new List<VRole>();

            using (var response = await httpClient.GetAsync("api/Admin/Access_Role_get"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                roles = JsonConvert.DeserializeObject<List<VRole>>(apiResponse);
            }
            return roles;
        }
        public async Task<List<VUserRole>> Access_UserRole_Get_By_Id(int id)
        {
            List<VUserRole> userRoles = new List<VUserRole>();

            using (var response = await httpClient.GetAsync("api/Admin/Access_UserRole_Get_By_Id/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                userRoles = JsonConvert.DeserializeObject<List<VUserRole>>(apiResponse);
            }
            return userRoles;
        }

        public async Task<ResponseResult> Access_UserRole_delete(UserRoleViewModel model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/admin/Access_UserRole_delete", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }

        public async Task<List<VUserRole>> Access_UserRole_get()
        {
            List<VUserRole> userRoles = new List<VUserRole>();
            using (var response = await httpClient.GetAsync("api/admin/Access_UserRole_get"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                userRoles = JsonConvert.DeserializeObject<List<VUserRole>>(apiResponse);
            }
            return userRoles;
        }

        public async Task<ResponseResult> Access_UserRole_insert(UserRoleViewModel model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/admin/Access_UserRole_insert", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }  
        public async Task<ResponseResult> Access_UserRole_update(UserRoleViewModel model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/admin/Access_UserRole_update", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }

        public async Task<ResponseResult> Master_Approval_delete(UserRoleViewModel model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/admin/Master_Approval_delete", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }

        public async Task<List<VUserRole>> Master_Approval_get()
        {
            List<VUserRole> userRoles = new List<VUserRole>();
            using (var response = await httpClient.GetAsync("api/admin/Master_Approval_get"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                userRoles = JsonConvert.DeserializeObject<List<VUserRole>>(apiResponse);
            }
            return userRoles;
        }

        public async Task<ResponseResult> Master_Approval_insert(UserRoleViewModel model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/admin/Master_Approval_insert", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }

        public async Task<List<VUserRole>> Master_Approval_Get_By_Id(int id)
        {
            List<VUserRole> userRoles = new List<VUserRole>();

            using (var response = await httpClient.GetAsync("api/Admin/Master_Approval_Get_By_Id/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                userRoles = JsonConvert.DeserializeObject<List<VUserRole>>(apiResponse);
            }
            return userRoles;
        }

        public async Task<ResponseResult> Master_Approval_update(UserRoleViewModel model)
        {
            ResponseResult responseResult = new ResponseResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync("api/admin/Master_Approval_update", content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                responseResult = JsonConvert.DeserializeObject<ResponseResult>(apiResponse);
            }
            return responseResult;
        }

        public async Task<List<VUserRole>> Master_Approval_Get_By_actionId(int id)
        {
            List<VUserRole> userRoles = new List<VUserRole>();

            using (var response = await httpClient.GetAsync("api/Admin/Master_Approval_Get_By_actionId/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                userRoles = JsonConvert.DeserializeObject<List<VUserRole>>(apiResponse);
            }
            return userRoles;
        }

        public async Task<List<VUserRole>> Access_UserRole_Get_By_ActionId(int id)
        {
            List<VUserRole> userRoles = new List<VUserRole>();

            using (var response = await httpClient.GetAsync("api/Admin/Access_UserRole_Get_By_ActionId/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                userRoles = JsonConvert.DeserializeObject<List<VUserRole>>(apiResponse);
            }
            return userRoles;
        }
    }
}

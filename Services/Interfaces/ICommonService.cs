using SharedObjects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICommonService
    {
        Task<List<VRole>> Access_Role_get();
        Task<List<VStatus>> Master_Status_get();
        Task<List<VPartNumber>> PartNumber_get(int custId);
        Task<List<VWorkWeek>> WorkWeek_get(int custId);
        Task<List<VCustomer>> Master_Customer_Get(string NtLogin);

    }
}

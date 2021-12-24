using SharedObjects.Common;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPendingService
    {
        Task<List<VPending>> Get();
        Task<ResponseResult> Action(PendingViewModel model);
    }
}

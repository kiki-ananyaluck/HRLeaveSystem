using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveSystem.Application.Repositories;

public interface IUnitOfWork
{
    ILeaveRequestRepository LeaveRequests { get; }
    Task<int> SaveAsync();
}

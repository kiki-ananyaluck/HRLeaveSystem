using HRLeaveSystem.Domain.Entities;

namespace HRLeaveSystem.Application.Repositories;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    // เพิ่ม method พิเศษที่เกี่ยวกับ LeaveRequest ได้ที่นี่
}

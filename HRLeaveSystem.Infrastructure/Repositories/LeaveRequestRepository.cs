using HRLeaveSystem.Application.Repositories;
using HRLeaveSystem.Domain.Entities;
using HRLeaveSystem.Infrastructure.Data;

namespace HRLeaveSystem.Infrastructure.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(AppDbContext context) : base(context) { }

    // เพิ่ม method พิเศษที่ใช้เฉพาะ LeaveRequest ได้ที่นี่
}

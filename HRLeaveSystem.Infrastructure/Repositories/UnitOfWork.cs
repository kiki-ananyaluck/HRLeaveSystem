using HRLeaveSystem.Application.Repositories;
using HRLeaveSystem.Infrastructure.Data;

namespace HRLeaveSystem.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public ILeaveRequestRepository LeaveRequests { get; }

    public UnitOfWork(AppDbContext context, ILeaveRequestRepository leaveRequestRepo)
    {
        _context = context;
        LeaveRequests = leaveRequestRepo;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

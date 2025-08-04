using HRLeaveSystem.Application.DTOs;
using HRLeaveSystem.Domain.Entities;

namespace HRLeaveSystem.Application.Interfaces;

public interface ILeaveRequestService
{
    Task<List<LeaveRequest>> GetAllAsync();
    Task<LeaveRequest> CreateAsync(CreateLeaveRequestDto dto);
}

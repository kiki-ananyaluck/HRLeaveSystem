using AutoMapper;
using HRLeaveSystem.Application.DTOs;
using HRLeaveSystem.Application.Interfaces;
using HRLeaveSystem.Application.Repositories;
using HRLeaveSystem.Domain.Entities;

namespace HRLeaveSystem.Application.Services;

public class LeaveRequestService : ILeaveRequestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LeaveRequestService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<LeaveRequest>> GetAllAsync()
    {
        var data = await _unitOfWork.LeaveRequests.GetAllAsync();
        return data.ToList();
    }

    public async Task<LeaveRequest> CreateAsync(CreateLeaveRequestDto dto)
    {
        var entity = _mapper.Map<LeaveRequest>(dto);
        await _unitOfWork.LeaveRequests.AddAsync(entity);
        await _unitOfWork.SaveAsync();
        return entity;
    }
}

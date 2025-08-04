using AutoMapper;
using HRLeaveSystem.Application.DTOs;
using HRLeaveSystem.Application.Interfaces;
using HRLeaveSystem.Domain.Entities;
using HRLeaveSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveSystem.Application.Services;

public class LeaveRequestService : ILeaveRequestService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public LeaveRequestService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LeaveRequest>> GetAllAsync()
    {
        return await _context.LeaveRequests.ToListAsync();
    }

    public async Task<LeaveRequest> CreateAsync(CreateLeaveRequestDto dto)
    {
        var entity = _mapper.Map<LeaveRequest>(dto);
        _context.LeaveRequests.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}

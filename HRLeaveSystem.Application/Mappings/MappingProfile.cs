using AutoMapper;
using HRLeaveSystem.Application.DTOs;
using HRLeaveSystem.Domain.Entities;

namespace HRLeaveSystem.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLeaveRequestDto, LeaveRequest>();
    }
}

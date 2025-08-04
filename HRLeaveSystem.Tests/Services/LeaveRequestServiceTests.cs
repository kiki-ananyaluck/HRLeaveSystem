using AutoMapper;
using HRLeaveSystem.Application.DTOs;
using HRLeaveSystem.Application.Interfaces;
using HRLeaveSystem.Application.Repositories;
using HRLeaveSystem.Application.Services;
using HRLeaveSystem.Domain.Entities;
using Moq;
using Xunit;

namespace HRLeaveSystem.Tests.Services;

public class LeaveRequestServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly LeaveRequestService _service;

    public LeaveRequestServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _service = new LeaveRequestService(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnLeaveRequests()
    {
        // Arrange
        var dummyData = new List<LeaveRequest>
        {
            new LeaveRequest { Id = 1, EmployeeId = "EMP01" },
            new LeaveRequest { Id = 2, EmployeeId = "EMP02" }
        };

        var mockRepo = new Mock<ILeaveRequestRepository>();
        mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(dummyData);

        _mockUnitOfWork.Setup(u => u.LeaveRequests).Returns(mockRepo.Object);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("EMP01", result[0].EmployeeId);
    }

    [Fact]
    public async Task CreateAsync_ShouldMapAndSave()
    {
        // Arrange
        var dto = new CreateLeaveRequestDto
        {
            EmployeeId = "EMP99",
            StartDate = DateTime.Today,
            EndDate = DateTime.Today.AddDays(2),
            LeaveType = "vacation"
        };

        var mappedEntity = new LeaveRequest { Id = 99, EmployeeId = dto.EmployeeId };

        _mockMapper.Setup(m => m.Map<LeaveRequest>(dto)).Returns(mappedEntity);

        var mockRepo = new Mock<ILeaveRequestRepository>();
        _mockUnitOfWork.Setup(u => u.LeaveRequests).Returns(mockRepo.Object);

        // Act
        var result = await _service.CreateAsync(dto);

        // Assert
        mockRepo.Verify(r => r.AddAsync(mappedEntity), Times.Once);
        _mockUnitOfWork.Verify(u => u.SaveAsync(), Times.Once);
        Assert.Equal("EMP99", result.EmployeeId);
    }
}

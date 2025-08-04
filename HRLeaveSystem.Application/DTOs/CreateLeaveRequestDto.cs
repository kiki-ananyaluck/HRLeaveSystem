namespace HRLeaveSystem.Application.DTOs;

public class CreateLeaveRequestDto
{
    public string EmployeeId { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveType { get; set; } = string.Empty;
    public string? Reason { get; set; }
}

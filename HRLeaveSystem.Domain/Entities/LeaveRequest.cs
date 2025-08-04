namespace HRLeaveSystem.Domain.Entities;

public class LeaveRequest
{
    public int Id { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string LeaveType { get; set; } = string.Empty;
    public string? Reason { get; set; }
    public bool IsApproved { get; set; }
    public DateTime DateRequested { get; set; } = DateTime.UtcNow;
}

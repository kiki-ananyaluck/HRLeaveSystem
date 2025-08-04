using FluentValidation;
using HRLeaveSystem.Application.DTOs;

namespace HRLeaveSystem.Application.Validators;

public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequestDto>
{
    public CreateLeaveRequestValidator()
    {
        RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Employee ID is required");
        RuleFor(x => x.StartDate).LessThanOrEqualTo(x => x.EndDate)
            .WithMessage("Start date must be before or equal to end date");
        RuleFor(x => x.LeaveType).NotEmpty();
    }
}

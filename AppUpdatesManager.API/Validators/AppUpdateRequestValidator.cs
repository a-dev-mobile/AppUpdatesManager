using AppUpdatesManager.API.Models.Requests;
using FluentValidation;

public class AppUpdateRequestValidator : AbstractValidator<AppUpdateRequest>
{
    public AppUpdateRequestValidator()
    {
        RuleFor(request => request.Checksum).NotEmpty().WithMessage("Checksum is required");
        RuleFor(request => request.UpdateDescription).NotEmpty().WithMessage("UpdateDescription is required");
        RuleFor(request => request.File).NotNull().Must(file => file?.Length > 0).WithMessage("File is required");
    }
}

namespace AppUpdatesManager.Domain.Models;

public class UpdatePolicies
{
    public required UpdateRequirementPolicy HardUpdatePolicy { get; set; }
    public required UpdateRequirementPolicy SoftUpdatePolicy { get; set; }
}
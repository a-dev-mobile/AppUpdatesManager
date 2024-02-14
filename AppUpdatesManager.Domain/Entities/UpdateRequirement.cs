namespace AppUpdatesManager.Domain.Entities
{
    public class UpdateRequirement
    {
        public int UpdateRequirementId { get; set; }
        public required UpdateStrategy HardUpdate { get; set; }
        public required UpdateStrategy SoftUpdate { get; set; }
    }
}

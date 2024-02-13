using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppUpdatesManager.Infrastructure.Entities
{
    [Table("UpdateRequirements")]
    public class UpdateRequirementEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UpdateRequirementId { get; set; }

        public virtual required UpdateStrategyEntity HardUpdate { get; set; }
        public virtual required UpdateStrategyEntity SoftUpdate { get; set; }
    }
}

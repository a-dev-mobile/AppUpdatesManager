using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppUpdatesManager.Infrastructure.Entities
{
    [Table("UpdateStrategies")]
    public class UpdateStrategyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UpdateStrategyId { get; set; }

        [Required]
        public int MinimumCode { get; set; }

        public int UpdateRequirementId { get; set; }
        public virtual required UpdateRequirementEntity UpdateRequirement { get; set; }
    }
}

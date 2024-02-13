using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppUpdatesManager.Infrastructure.Entities
{
    [Table("DownloadDetails")]
    public class DownloadDetailEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DownloadDetailId { get; set; }

        [Required]
        [Url]
        public required string DownloadUrl { get; set; }

        public virtual required SoftwareVersionEntity CurrentVersion { get; set; }
        public virtual required UpdateRequirementEntity RequiredUpdate { get; set; }
    }
}

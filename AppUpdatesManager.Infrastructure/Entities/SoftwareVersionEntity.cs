using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AppUpdatesManager.Infrastructure.Entities
{
    [Table("SoftwareVersions")]
    public class SoftwareVersionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SoftwareVersionId { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [StringLength(64)] // Assuming checksum is a SHA256 hash
        public required string Checksum { get; set; }

        public long SizeInBytes { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int DownloadDetailId { get; set; }
        public virtual required DownloadDetailEntity DownloadDetail { get; set; }
    }
}

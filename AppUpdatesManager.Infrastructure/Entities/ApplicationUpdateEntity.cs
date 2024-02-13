using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppUpdatesManager.Infrastructure.Entities
{
    [Table("ApplicationUpdates")]
    public class ApplicationUpdateEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationUpdateId { get; set; }

        [Required]
        [StringLength(255)]
        public required string Name { get; set; }

        [Required]
        [StringLength(255)]
        public required string PackageName { get; set; }

        public virtual required ICollection<DownloadDetailEntity> DownloadDetails { get; set; }
    }
}

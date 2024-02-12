using System.ComponentModel.DataAnnotations;

namespace AppUpdatesManager.Application.DTOs
{
    public class CheckSuccessResponse
    {
        [Required]
        public required string UpdateType { get; set; }

        [Required]
        public required VersionInfo LatestVersion { get; set; }
    }

    public class VersionInfo
    {
        [Required]
        public required string Url { get; set; }

        public int VersionCode { get; set; }

        [Required]
        public required string VersionName { get; set; }

        public long FileSize { get; set; }

        public string? UpdateDescription { get; set; }

        [Required]
        public required string Checksum { get; set; }
    }
}

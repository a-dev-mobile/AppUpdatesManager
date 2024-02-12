using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;
namespace AppUpdatesManager.Application.DTOs
{
    // Description: The request payload for checking application updates.
    public class CheckRequest
    {
        // PackageName is the unique identifier of the application package.
        [Required(ErrorMessage = "PackageName is required")]
        [JsonPropertyName("packageName")]
        public required string PackageName { get; set; }

        // VersionCode is the current version code of the application.
        // Must be greater than 0.
        [Required(ErrorMessage = "VersionCode is required")]
        [Range(1, int.MaxValue, ErrorMessage = "VersionCode must be greater than 0")]
        [JsonPropertyName("versionCode")]
        public int VersionCode { get; set; }

        // VersionName is the current version name of the application.
        [Required(ErrorMessage = "VersionName is required")]
        [JsonPropertyName("versionName")]
        public required string VersionName { get; set; }

        // InstallerPackageName is the package name of the installer.
        [Required(ErrorMessage = "InstallerPackageName is required")]
        [JsonPropertyName("installerPackageName")]
        public required string InstallerPackageName { get; set; }

        // New field for debug mode
        // Description: If true, the API will always return the latest version information regardless of the actual version status. Useful for debugging purposes.
        [JsonPropertyName("debugMode")]
        public bool? DebugMode { get; set; }

     
    }
}

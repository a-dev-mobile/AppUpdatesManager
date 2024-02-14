namespace AppUpdatesManager.Application.DTOs
{
    public class AppUpdateDto
    {
        public required byte[] FileContent { get; set; }
        public required string FileName { get; set; }
        public required string Checksum { get; set; }
        public string? UpdateDescription { get; set; }
    }
}

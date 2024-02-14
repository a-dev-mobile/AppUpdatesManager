

namespace AppUpdatesManager.API.Models.Requests
{
    public class AppUpdateRequest
    {
        public IFormFile? File { get; set; }
        public string? Checksum { get; set; }
        public string? UpdateDescription { get; set; }

    }
}

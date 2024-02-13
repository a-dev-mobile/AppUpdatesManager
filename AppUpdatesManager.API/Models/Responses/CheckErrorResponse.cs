using System.ComponentModel.DataAnnotations;


namespace AppUpdatesManager.Application.DTOs
{
    /// <summary>
    /// The response payload returned after a user tries to log in.
    /// </summary>
    public class CheckErrorResponse
    {

        [Required]

        public required string Message { get; set; }

        [Required]


        public required string Status { get; set; }
    }
}

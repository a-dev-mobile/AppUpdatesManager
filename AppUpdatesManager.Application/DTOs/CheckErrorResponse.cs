using System.ComponentModel.DataAnnotations;


namespace AppUpdatesManager.Application.DTOs
{
    /// <summary>
    /// The response payload returned after a user tries to log in.
    /// </summary>
    public class CheckErrorResponse
    {
        /// <summary>
        /// Provides information.
        /// </summary>

        /// <example>REGISTRATION_SUCCESSFUL</example>
        [Required]

        public required string Message { get; set; }

        [Required]

        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>


        public required string Status { get; set; }
    }
}

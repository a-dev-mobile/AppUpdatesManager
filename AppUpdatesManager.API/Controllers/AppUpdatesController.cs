using System.Net;
using AppUpdatesManager.Application.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace AppUpdatesManager.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class AppUpdatesController : ControllerBase
    {
        /// <summary>
        /// Check for application updates.
        /// </summary>
        /// <remarks>
        /// Checks if there is an update available for a given application package.
        /// In debug mode, it always returns the latest version information.
        /// <para>
        /// Sample request:
        /// </para>
        /// </remarks>
        /// <param name="request">Check Request - includes details such as package version, current version of the application, and debug mode.</param>
        /// <returns>Success Response - returns the type of update required ('hard', 'soft', or 'none') and the latest version information, including the checksum, if an update is available.</returns>
        /// <response code="200">Success Response - returns the type of update required ('hard', 'soft', or 'none') and the latest version information, including the checksum, if an update is available.</response>
        /// <response code="400">Bad Request - Invalid request body or parameters.</response>
        /// <response code="404">Not Found - Update information for the requested package is not found.</response>
        /// <response code="500">Internal Server Error - Unexpected error occurred during processing.</response>
        [HttpPost("check")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CheckSuccessResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Check([FromBody] CheckRequest request)
        {
            await Task.Delay(1000); // Simulated delay
            var response = new CheckSuccessResponse
            {
                UpdateType = "hard",
                LatestVersion = new VersionInfo { Url = "https://example.com/latest-version", VersionName = "2.0.0", Checksum = "abcd1234" }
            };
            return Ok(response);
        }
    }
}

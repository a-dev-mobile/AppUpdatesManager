using System.Net;
using AppUpdatesManager.API.Models.Requests;
using AppUpdatesManager.Application.DTOs;
using AppUpdatesManager.Application.Models;
using AppUpdatesManager.Application.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppUpdatesManager.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class AppUpdatesController : ControllerBase
    {
        private readonly IAppUpdateService _appUpdateService;
        private readonly IMapper _mapper;

        public AppUpdatesController(IAppUpdateService appUpdateService, IMapper mapper)
        {
            _appUpdateService = appUpdateService;
            _mapper = mapper;
        }

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
        /// <summary>
        /// Создает обновление приложения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /create
        ///     {
        ///        "checksum": "abcd1234",
        ///        "updateDescription": "Описание обновления",
        ///        "file": "Файл обновления"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Обновление приложения успешно создано</response>
        /// <response code="400">Ошибка: неверный запрос, недопустимый чек-сумм или описание обновления, файл обновления отсутствует</response>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)] // Успешный ответ без тела
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromForm] AppUpdateRequest request)
        {
            var validationResponse = ValidateAppUpdateRequest(request);
            if (validationResponse != null)
            {
                return BadRequest(validationResponse);
            }

            // Логика обработки, если ошибок нет
            // var dto = _mapper.Map<AppUpdateDto>(request);
            // var result = await _appUpdateService.AddUpdateAsync(dto);
            await Task.Delay(1000); // Эмуляция асинхронной операции

            return Ok(); // Вернуть успешный результат, если ошибок нет
        }

        private ErrorResponse? ValidateAppUpdateRequest(AppUpdateRequest request)
        {
            var errorResponse = new ErrorResponse();

            if (string.IsNullOrEmpty(request.Checksum))
            {
                errorResponse.Errors.Add(new ErrorDetails
                {
                    Status = ErrorStatus.InvalidChecksum,
                    Message = "Checksum is required"
                });
            }

            if (string.IsNullOrEmpty(request.UpdateDescription))
            {
                errorResponse.Errors.Add(new ErrorDetails
                {
                    Status = ErrorStatus.InvalidDescription,
                    Message = "UpdateDescription is required"
                });
            }

            if (request.File == null || request.File.Length == 0)
            {
                errorResponse.Errors.Add(new ErrorDetails
                {
                    Status = ErrorStatus.InvalidFile.ToString(),
                    Message = "File is required"
                });
            }

            // Здесь могут быть другие проверки

            return errorResponse.Errors.Count > 0 ? errorResponse : null;
        }
    }
}

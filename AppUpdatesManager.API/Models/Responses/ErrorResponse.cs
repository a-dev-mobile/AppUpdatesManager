using System.Collections.Generic; // Необходимо для использования List<>
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AppUpdatesManager.Application.Models
{


    public static class ErrorStatus
    {
        public const string InvalidChecksum = "INVALID_CHECKSUM";
        public const string InvalidDescription = "INVALID_DESCRIPTION";
        public const string InvalidFile = "INVALID_FILE";
        // Добавьте другие статусы по необходимости
    }







    // Определение класса для хранения сообщения и статуса
    public class ErrorDetails
    {
        public required string Status { get; set; }
        public string? Message { get; set; }
    }
    public class ErrorResponse
    {
        // Использование списка объектов ErrorDetails для хранения нескольких сообщений и статусов
        public List<ErrorDetails> Errors { get; set; } = new List<ErrorDetails>();
    }
}

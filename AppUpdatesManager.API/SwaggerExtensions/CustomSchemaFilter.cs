
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using AppUpdatesManager.Application.DTOs;
using AppUpdatesManager.Application.Models;

namespace LinkShortener.API.SwaggerExtensions
{
    public class CustomSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CheckRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["packageName"] = new OpenApiString("com.wayofdt.kidneysmart"),
                    ["versionCode"] = new OpenApiInteger(1),
                    ["versionName"] = new OpenApiString("1.0.0"),
                    ["installerPackageName"] = new OpenApiString("apk"),
                    ["debugMode"] = new OpenApiNull(),
                };
            }
            if (context.Type == typeof(CheckSuccessResponse))
            {
                schema.Example = new OpenApiObject
                {
                    ["UpdateType"] = new OpenApiString("hard // hard soft none"),
                    ["Url"] = new OpenApiString("https://www.youtube.com/watch?v=dp1WRyR0TiE"),
                    ["versionCode"] = new OpenApiInteger(1),
                    ["VersionName"] = new OpenApiString("1.0.1"),
                    ["Checksum"] = new OpenApiString("sdf893274ydfdfg8435"),

                };
            }
            if (context.Type == typeof(ErrorDetails))
            {
                schema.Properties["status"].Enum = new List<IOpenApiAny>
            {
                new OpenApiString(ErrorStatus.InvalidChecksum),
                new OpenApiString(ErrorStatus.InvalidDescription),
                new OpenApiString(ErrorStatus.InvalidFile)
                // Добавьте другие статусы по мере необходимости
            };
            }
        }

    }
}

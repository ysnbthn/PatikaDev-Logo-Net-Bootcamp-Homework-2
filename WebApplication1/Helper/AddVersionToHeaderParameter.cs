using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApplication1.Helper
{
    public class AddVersionToHeaderParameter : IOperationFilter
    {
        // class for putting header option in swagger
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "app-version",
                In = ParameterLocation.Header,
                Description = "Application version",
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("2.0.0")
                }
            });
            
        }
    }
}

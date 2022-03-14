using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Filters
{
    // filter for hiding endpoint
    public class HideFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var removePath = swaggerDoc.Paths.SingleOrDefault(x => x.Key.Contains("/hidden"));

            swaggerDoc.Paths.Remove(removePath.Key);
        }
    }
}

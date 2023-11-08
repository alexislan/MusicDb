using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UsersApi
{
    public class JwtAuthOperationsFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var Attributes = context.ApiDescription.CustomAttributes();
            var isAuthRequired = Attributes.Any(attr => attr.GetType() == typeof(AuthorizeAttribute));
            var isAllowAnonymous = Attributes.Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute));

            if (!isAuthRequired || isAllowAnonymous) return;

            operation.Security = new List<OpenApiSecurityRequirement>
           {
                new OpenApiSecurityRequirement
                {
                    [
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Token"}
                        }
                    ] = new string[] { }
                }
            };
        }
    }
}

//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;
//using System.Linq;

//namespace RealEstateProject
//{
//    public class AuthorizedOnlyDocumentFilter : IDocumentFilter
//    {
//        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
//        {
//            var pathsToRemove = swaggerDoc.Paths
//                .Where(pathItem =>
//                    pathItem.Value.Operations
//                        .Any(op => op.Value.Security != null && op.Value.Security.Any()))
//                .Select(path => path.Key)
//                .ToList();

//            foreach (var path in pathsToRemove)
//            {
//                swaggerDoc.Paths.Remove(path);
//            }
//        }
//    }
//}

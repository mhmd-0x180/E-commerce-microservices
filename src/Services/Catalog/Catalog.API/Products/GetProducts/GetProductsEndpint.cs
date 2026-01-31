using Catalog.API.Models;
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProduts
{
    public record GetProductRequest();
    public record GetProductResponse(IEnumerable<Product> Products);
    public class GetProductsEndpint :ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) => 
            {
                var result = await sender.Send(new GetProductQuery());

                var response =result.Adapt<GetProductResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<CreateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get All Products")
            .WithDescription("Get All Products");
        }

    }
}

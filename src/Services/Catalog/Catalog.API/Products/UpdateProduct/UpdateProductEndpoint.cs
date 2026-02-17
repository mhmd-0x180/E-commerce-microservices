
namespace Catalog.API.Products.UpdateProduct
{

    record UpdateProductRequest(Guid Id, string Name, List<string> Catagory, string Description,
        string ImageFile, decimal Price);
    record UpdateProductResponse(bool isSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async (UpdateProductRequest request,ISender sender) => 
            {
                var command = request.Adapt<UpdateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            });
            
        }
    }
}

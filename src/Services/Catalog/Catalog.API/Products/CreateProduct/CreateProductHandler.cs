using BuildingBlocks.CQRS;
using Catalog.API.Models;


namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,
        List<string> Catagory,
        string Description,
        string ImageFile,
        decimal Price):ICommand<CreateProdcutResult>;

    public record CreateProdcutResult(Guid Id);
    internal class CreateProductCommandHandler (IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProdcutResult>
    {
        public async Task<CreateProdcutResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            var product = new Product
            {
                Name = command.Name,
                Catagory = command.Catagory,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };
            
            //save to database

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //return the result
            return new CreateProdcutResult (product.Id);

        }
    }
}

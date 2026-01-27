using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name
        ,List<string> Catagory
        ,string Description
        ,string ImageFile
        ,decimal Price):IRequest<CreateProdcutResult>;

    public record CreateProdcutResult(Guid Id);
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProdcutResult>
    {
        public Task<CreateProdcutResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using BuildingBlocks.CQRS;
using Catalog.API.Models;



namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,
        List<string> Catagory,
        string Description,
        string ImageFile,
        decimal Price) : ICommand<CreateProdcutResult>;

    public record CreateProdcutResult(Guid Id);



    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name is required");
            RuleFor(x => x.Catagory).NotEmpty().WithMessage("Product Catagory is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Product ImageFile is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Product Price is required");
        }
    }



    internal class CreateProductCommandHandler(IDocumentSession session
        ,IValidator<CreateProductCommand> validator) : ICommandHandler<CreateProductCommand, CreateProdcutResult>
    {
        public async Task<CreateProdcutResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await validator.ValidateAsync(command,cancellationToken);
            var errors = result.Errors.Select(x=>x.ErrorMessage).ToList();
            if (errors.Any()) 
            {
                throw new ValidationException(errors.FirstOrDefault());
            }



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
            return new CreateProdcutResult(product.Id);

        }
    }
}

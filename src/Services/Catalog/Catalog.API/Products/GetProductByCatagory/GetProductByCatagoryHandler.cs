using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductByCatagory
{

    public record GetProductByCatagoryQuery(string Catagory) : IQuery<GetProductByCatagoryResult>;
    public record GetProductByCatagoryResult(IEnumerable<Product> Products);
    internal class GetProductByCatagoryHandler(IDocumentSession session, ILogger<GetProductByCatagoryHandler> logger) : IQueryHandler<GetProductByCatagoryQuery, GetProductByCatagoryResult>
    {
        public async Task<GetProductByCatagoryResult> Handle(GetProductByCatagoryQuery query, CancellationToken cancellationToken)
        {

            logger.LogInformation("GetProductByCategoryHandler.Handle called with {@Query}", query);

            var products = await session.Query<Product>().Where(p => p.Catagory.Contains(query.Catagory)).ToListAsync();

            return new GetProductByCatagoryResult(products);
        }
    }
}

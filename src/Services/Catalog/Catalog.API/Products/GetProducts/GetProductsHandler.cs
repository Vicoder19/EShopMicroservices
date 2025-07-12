using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.GetProducts
{
       
    public record GetProductsResult(IEnumerable<Product> Products);
    public record GetProductsQuery() : IQuery<GetProductsResult>;

    public class GetProductsHandler(IDocumentSession session, ILogger<GetProductsHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsHandler.Handle called with {@Query}");
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductsResult(products);
        }
    }
}

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Catalog.API.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Product not found")
        {

        }
    }
}

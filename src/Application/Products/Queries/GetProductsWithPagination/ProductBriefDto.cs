using dotnet_clean_architecture.Domain.Entities;
using dotnet_clean_architecture.Application.Common.Mappings;

namespace dotnet_clean_architecture.Application.Products.Queries.GetProductsWithPagination;

public class ProductBriefDto : IMapFrom<Product>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
}
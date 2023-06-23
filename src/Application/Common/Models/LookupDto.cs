using dotnet_clean_architecture.Application.Common.Mappings;
using dotnet_clean_architecture.Domain.Entities;

namespace dotnet_clean_architecture.Application.Common.Models;

public class LookupDto : IMapFrom<Product>
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

namespace dotnet_clean_architecture.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Image { get; set; }
}

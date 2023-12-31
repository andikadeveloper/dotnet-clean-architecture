namespace dotnet_clean_architecture.Domain.Events;

public class ProductCreatedEvent : BaseEvent
{
    public ProductCreatedEvent(Product product)
    {
        Product = product;
    }

    public Product Product;
}
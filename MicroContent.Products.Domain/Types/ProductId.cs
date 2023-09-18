using MicroContent.Transactions.Domain.Exeptions;

namespace MicroContent.Products.Domain.Types;

public class ProductId
{
    public Guid Value { get; set; }

    public ProductId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new InvalidEntityIdException(value);
        }

        Value = value;
    }
    
    public static implicit operator Guid(ProductId userId)
        => userId.Value;
    
    public static implicit operator ProductId(Guid value)
        => new(value);
   
    public static implicit operator string(ProductId userId)
        => userId.Value.ToString();

    public static implicit operator ProductId?(string? value)
        => string.IsNullOrWhiteSpace(value) ? null : Guid.Parse(value);
}
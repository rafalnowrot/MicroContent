namespace MicroContent.Products.Domain.Value_Objects;

public sealed record ProductType(string Value)
{
    public const string Unverified = nameof(Unverified);
    public const string Verified = nameof(Verified);
    public const string Rejected = nameof(Rejected);

    public static implicit operator string(ProductType state)
        => state.Value;

    public static implicit operator ProductType(string value)
        => new(value);
}
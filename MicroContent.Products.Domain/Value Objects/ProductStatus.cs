namespace MicroContent.Products.Domain.Value_Objects;

public sealed record ProductStatus(string Value)
{
    public const string Unverified = nameof(Unverified);
    public const string Verified = nameof(Verified);
    public const string Rejected = nameof(Rejected);

    public static implicit operator string(ProductStatus state)
        => state.Value;

    public static implicit operator ProductStatus(string value)
        => new(value);
}
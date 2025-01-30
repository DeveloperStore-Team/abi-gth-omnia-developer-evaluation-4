namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public readonly struct SaleNumber
{
    public string Value { get; }

    public SaleNumber()
    {
        Value = GenerateSaleNumber();
    }

    private static string GenerateSaleNumber()
    {
        var random = new Random();
        return random.Next(1000000, 9999999).ToString();
    }

    public override string ToString() => Value;
}

namespace CarRental.Domain.Shared;

public record Currency
{
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static readonly Currency Mxn = new("MXN");
    public static readonly Currency None = new("");
    private Currency(string code) => Code = code;
    public string Code { get; init; }
    public static IReadOnlyCollection<Currency> All = new[]
    {
        Usd,
        Eur,
        Mxn
    };
    public static Currency FromeCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException("Currency code is invalid.");
    }
}
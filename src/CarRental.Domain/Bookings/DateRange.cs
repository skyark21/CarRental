namespace CarRental.Domain.Bookings;

public sealed record DateRange
{
    private DateRange()
    {

    }
    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }
    public int DaysQuantity => End.DayNumber - Start.DayNumber;
    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new InvalidOperationException("Start date precede end date.");
        }
        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}
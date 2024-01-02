using CarRental.Domain.Abstracts;

namespace CarRental.Domain.Reviews;

public static class ReviewErrors
{
    public static readonly Error NotEligible = new Error
    (
        "Review.NotEligible",
        "Booking has not been completed"
    );
}
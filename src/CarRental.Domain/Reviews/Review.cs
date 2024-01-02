using CarRental.Domain.Abstracts;
using CarRental.Domain.Bookings;
using CarRental.Domain.Reviews.Events;

namespace CarRental.Domain.Reviews;

public sealed class Review : Entity
{
    public Guid VehicleId { get; private set; }
    public Guid BookingId { get; private set; }
    public Guid UserId { get; private set; }
    public Rating Rating { get; private set; }
    public Comment Comment { get; set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? LastModifiedOnUtc { get; private set; }
    public Review
    (
        Guid id,
        Guid vehicleId,
        Guid bookingId,
        Guid userId,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc
    ) : base(id)
    {
        VehicleId = vehicleId;
        BookingId = bookingId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }
    public static Result<Review> Create(Booking booking, Rating rating, Comment comment, DateTime utcNow)
    {
        if (booking.Status != BookingStatus.Completed)
        {
            return Result.Failure<Review>(ReviewErrors.NotEligible);
        }
        var review = new Review
        (
            Guid.NewGuid(),
            booking.VehicleId,
            booking.Id,
            booking.UserId,
            rating,
            comment,
            utcNow
        );
        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));
        return review;
    }
}
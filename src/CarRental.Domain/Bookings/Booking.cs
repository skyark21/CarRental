using CarRental.Domain.Abstracts;
using CarRental.Domain.Bookings.Events;
using CarRental.Domain.Shared;
using CarRental.Domain.Vehicles;

namespace CarRental.Domain.Bookings;

public sealed class Booking : Entity
{
    private Booking
    (
        Guid id,
        Guid userId,
        Guid vehicleId,
        BookingStatus status,
        DateRange duration,
        Money priceByPeriod,
        Money cleaningFee,
        Money amenities,
        Money totalPrice,
        DateTime createdOnUtc
    ) : base(id)
    {
        UserId = userId;
        VehicleId = vehicleId;
        Status = status;
        Duration = duration;
        PriceByPeriod = priceByPeriod;
        CleaningFee = cleaningFee;
        Amenities = amenities;
        TotalPrice = totalPrice;
        CreatedOnUtc = createdOnUtc;
    }
    public Guid UserId { get; private set; }
    public Guid VehicleId { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceByPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money Amenities { get; private set; }
    public Money TotalPrice { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CanceledOnUtc { get; private set; }
    public static Booking Reservation(Vehicle vehicle, Guid userId, PriceService priceService, DateRange duration, DateTime createdOnUtc)
    {
        var detailPrice = priceService.PriceCalculation(vehicle, duration);
        var booking = new Booking
        (
            Guid.NewGuid(),
            userId,
            vehicle.Id,
            BookingStatus.Reserved,
            duration,
            detailPrice.PriceByPeriod,
            detailPrice.CleaningFee,
            detailPrice.Amenities,
            detailPrice.TotalPrice,
            createdOnUtc
        );
        booking.RaiseDomainEvent(new BookingReservedDomainEvent(booking.Id));
        vehicle.LastTimeBookingOnUtc = createdOnUtc;
        return booking;
    }
    public Result Confirmed(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotReserved);
        }
        Status = BookingStatus.Confirmed;
        ConfirmedOnUtc = utcNow;
        RaiseDomainEvent(new BookingConfirmedDomainEvent(Id));
        return Result.Success();
    }
    public Result Rejected(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotReserved);
        }
        Status = BookingStatus.Rejected;
        RejectedOnUtc = utcNow;
        RaiseDomainEvent(new BookingRejectedDomainEvent(Id));
        return Result.Success();
    }
    public Result Canceled(DateTime utcNow)
    {
        if (Status != BookingStatus.Confirmed)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }
        var currentDate = DateOnly.FromDateTime(utcNow);
        if (currentDate > Duration.Start)
        {
            return Result.Failure(BookingErrors.AlreadyStarted);
        }
        Status = BookingStatus.Canceled;
        CanceledOnUtc = utcNow;
        RaiseDomainEvent(new BookingCanceledDomainEvent(Id));
        return Result.Success();
    }
    public Result Completed(DateTime utcNow)
    {
        if (Status != BookingStatus.Confirmed)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }
        Status = BookingStatus.Completed;
        CompletedOnUtc = utcNow;
        RaiseDomainEvent(new BookingCompletedDomainEvent(Id));
        return Result.Success();
    }
}
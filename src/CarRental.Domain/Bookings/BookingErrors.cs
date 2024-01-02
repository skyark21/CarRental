using CarRental.Domain.Abstracts;

namespace CarRental.Domain.Bookings;

public static class BookingErrors
{
    public static readonly Error NotFound = new Error
    (
        "Booking.Found",
        "Booking Id is not found"
    );
    public static readonly Error OverLap = new Error
    (
        "Booking.OverLap",
        "Vehicle is already reserved"
    );
    public static readonly Error NotReserved = new Error
    (
        "Booking.NotReserved",
        "Booking is not reserved"
    );
    public static readonly Error NotConfirmed = new Error
    (
        "Booking.NotConfirmed",
        "Booking is not confirmed"
    );
    public static readonly Error AlreadyStarted = new Error
    (
        "Booking.NotCanceled",
        "Booking has already started"
    );
}
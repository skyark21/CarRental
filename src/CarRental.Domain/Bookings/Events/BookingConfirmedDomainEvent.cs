using CarRental.Domain.Abstracts;

namespace CarRental.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent { }
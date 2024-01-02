using CarRental.Domain.Abstracts;

namespace CarRental.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(Guid CompletedId) : IDomainEvent { }
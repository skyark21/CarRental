using CarRental.Domain.Abstracts;

namespace CarRental.Domain.Bookings.Events;

public sealed record BookingRejectedDomainEvent(Guid RejectedId) : IDomainEvent { }
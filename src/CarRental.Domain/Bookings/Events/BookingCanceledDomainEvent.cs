using CarRental.Domain.Abstracts;

namespace CarRental.Domain.Bookings.Events;

public sealed record BookingCanceledDomainEvent(Guid CanceledId) : IDomainEvent { }
using CarRental.Domain.Abstracts;

namespace CarRental.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(Guid ConfirmedId) : IDomainEvent { }
using CarRental.Domain.Abstracts;

namespace CarRental.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent { }
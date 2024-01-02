using CarRental.Domain.Abstracts;

namespace CarRental.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid CreatedId) : IDomainEvent { }
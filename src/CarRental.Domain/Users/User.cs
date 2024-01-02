using CarRental.Domain.Abstracts;
using CarRental.Domain.Users.Events;

namespace CarRental.Domain.Users;

public sealed class User : Entity
{
    private User
    (
        Guid id,
        FirstName firstName,
        LastName lastName,
        Email email
    ) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public static User Create
    (
        FirstName firstName,
        LastName lastName,
        Email email
    )
    {
        if (firstName is null || lastName is null || email is null)
        {
            throw new InvalidOperationException("No null or empty values");
        }
        User user = new(Guid.NewGuid(), firstName, lastName, email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
        return user;
    }
}
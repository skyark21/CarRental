namespace CarRental.Domain.Vehicles;

public record Address
(
    string Street,
    string City,
    string State,
    string ZipCode,
    string Country
);
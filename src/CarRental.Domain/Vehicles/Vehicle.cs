using CarRental.Domain.Abstracts;
using CarRental.Domain.Shared;

namespace CarRental.Domain.Vehicles;

public sealed class Vehicle : Entity
{
    public Vehicle
    (
        Guid id,
        VehicleModel vehicleModel,
        Address address,
        Money price,
        Money cleaningFee,
        List<Amenity> amenities,
        DateTime createdOnUtc,
        DateTime? lastTimeBookingOnUtc
    ) : base(id)
    {
        VehicleModel = vehicleModel;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        Amenities = amenities;
        CreatedOnUtc = createdOnUtc;
        LastTimeBookingOnUtc = lastTimeBookingOnUtc;
    }
    public VehicleModel VehicleModel { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public List<Amenity> Amenities { get; private set; } = new();
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? LastTimeBookingOnUtc { get; internal set; }
}
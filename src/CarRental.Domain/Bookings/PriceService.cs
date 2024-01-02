using CarRental.Domain.Shared;
using CarRental.Domain.Vehicles;

namespace CarRental.Domain.Bookings;

public class PriceService
{
    public DetailPrice PriceCalculation(Vehicle vehicle, DateRange dateRange)
    {
        var currencyType = vehicle.Price!.Currency;

        var priceByPeriod = new Money(dateRange.DaysQuantity * vehicle.Price.Amount, currencyType);

        decimal percentageChange = 0;
        foreach (var amenity in vehicle.Amenities)
        {
            percentageChange += amenity switch
            {
                Amenity.AppleCar or Amenity.AndroidCar => 0.05m,
                Amenity.AirConditioner => 0.01m,
                Amenity.GPS => 0.01m,
                _ => 0
            };
        }
        var amenityCharges = Money.Zero(currencyType);

        if (percentageChange > 0)
        {
            amenityCharges = new Money
            (
                priceByPeriod.Amount * percentageChange,
                currencyType
            );
        }

        var totalPrice = Money.Zero();
        totalPrice += priceByPeriod;
        if (!vehicle.CleaningFee!.IsZero())
        {
            totalPrice += vehicle.CleaningFee;
        }

        totalPrice += amenityCharges;

        return new DetailPrice
        (
            priceByPeriod,
            vehicle.CleaningFee,
            amenityCharges,
            totalPrice
        );
    }
}
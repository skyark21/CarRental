using CarRental.Domain.Shared;

namespace CarRental.Domain.Bookings;

public record DetailPrice
(
    Money PriceByPeriod,
    Money CleaningFee,
    Money Amenities,
    Money TotalPrice

);
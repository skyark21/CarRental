namespace CarRental.Domain.Vehicles;

public interface IVehicleRepository
{
    Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Vehicle vehicle); // Pending to define
}
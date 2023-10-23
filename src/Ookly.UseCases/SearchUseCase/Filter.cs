namespace Ookly.UseCases.SearchUseCase;

public record Filters(
    int CountryId,
    int CategoryId,
    long? PriceFrom,
    long? PriceTo,
    int? CurrencyId,
    int? VehicleBrandId,
    int? VehicleModelId,
    int? VehicleYear,
    int? VehicleMileage,
    string? VehicleFuelType,
    string? VehicleColor);

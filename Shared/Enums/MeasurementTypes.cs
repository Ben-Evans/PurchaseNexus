namespace PurchaseNexus.Shared.Enums;

public static class MeasurementTypes
{
    public static MeasurementTypeEnum Item => new(1, nameof(Item), null, false);

    public static MeasurementTypeEnum Teaspoon => new(2, nameof(Teaspoon), "tsp.", true);
    public static MeasurementTypeEnum Tablespoon => new(3, nameof(Tablespoon), "tbsp.", true);
    public static MeasurementTypeEnum FluidOunce => new(4, nameof(FluidOunce), "fl oz", true);
    public static MeasurementTypeEnum Cup => new(5, nameof(Cup), "c", true);
    public static MeasurementTypeEnum Millilitre => new(6, nameof(Millilitre), "mL", true);
    public static MeasurementTypeEnum Litre => new(7, nameof(Litre), "L", true);
    public static MeasurementTypeEnum Gallon => new(8, nameof(Gallon), "gal", true);

    public static MeasurementTypeEnum Pound => new(9, nameof(Pound), "lb", false);
    public static MeasurementTypeEnum Ounce => new(10, nameof(Ounce), "oz", false);
    public static MeasurementTypeEnum Milligram => new(11, nameof(Milligram), "mg", false);
    public static MeasurementTypeEnum Gram => new(12, nameof(Gram), "g", false);
    public static MeasurementTypeEnum Kilogram => new(13, nameof(Kilogram), "kg", false);
}

// TODO: Allow for unit conversions directly on page
public record MeasurementTypeEnum(int Id, string Name, string? Abbreviation, bool VolumeBased) : Enumeration(Id, Name);

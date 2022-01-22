namespace PurchaseNexus.Shared.DomainModels;

public class MeasurementType : INamedDomainModel
{
    public MeasurementType(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    public string Name { get; set; }
}

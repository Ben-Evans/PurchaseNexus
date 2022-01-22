namespace PurchaseNexus.Shared.ApiQueries;

public record FoodQuery(string Name = "", int Skip = 0, int Take = 10, string? SortOrder = default)
{
    /*private string _name = string.Empty;
    public int Skip { get; init; } = 0;
    public int Take { get; init; } = 10;
    public string? SortOrder { get; init; }
    public string Name
    {
        get => _name;
        init => _name = value.Trim().ToLower();
    }*/
}

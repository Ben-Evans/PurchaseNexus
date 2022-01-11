namespace PurchaseNexus.Client.Pages;

public partial class Weather : ComponentBase
{
    [Inject] private IWeatherClient Client { get; set; }

    private ICollection<WeatherForecast> forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Client.GetAsync();
    }
}

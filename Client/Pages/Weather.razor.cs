namespace PurchaseNexus.Client.Pages;

public partial class Weather : ComponentBase
{
    [Inject] private IWeatherClient Client { get; set; } = NotNullHelper.Injected<IWeatherClient>();

    private ICollection<WeatherForecast> _forecasts = new List<WeatherForecast>();

    protected override async Task OnInitializedAsync()
    {
        _forecasts = await Client.GetAsync();
    }
}

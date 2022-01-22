using FluentValidation.AspNetCore;

namespace PurchaseNexus.Server.StartupConfig;

public static class RegisterValidatorsConfig
{
    public static IMvcBuilder AddValidators(this IMvcBuilder mvcBuilder)
    {
        // TODO: Also consider "manual" DI
        // https://docs.fluentvalidation.net/en/latest/aspnet.html
        // ie.
        // mvcBuilder.AddFluentValidation();
        // services.AddScoped<IFoodValidator, FoodValidator>();
        return mvcBuilder.AddFluentValidation(config =>
        {
            config.RegisterValidatorsFromAssemblyContaining<TodoListValidator>();
            config.DisableDataAnnotationsValidation = true;
            // config.AutomaticValidationEnabled = false;
        });
    }
}

using FoodDeliveryBlazorApp;
using FoodDeliveryBlazorApp.Features.Addresses.Services;
using FoodDeliveryBlazorApp.Features.AppUpdate.Services;
using FoodDeliveryBlazorApp.Features.Auth;
using FoodDeliveryBlazorApp.Features.Auth.Services;
using FoodDeliveryBlazorApp.Features.Connectivity.Services;
using FoodDeliveryBlazorApp.Features.ErrorHandling.Services;
using FoodDeliveryBlazorApp.Features.Home.Services;
using FoodDeliveryBlazorApp.Features.Localization.Services;
using FoodDeliveryBlazorApp.Features.Notifications.Services;
using FoodDeliveryBlazorApp.Features.Profile.Services;
using FoodDeliveryBlazorApp.Features.Theming.Services;
using FoodDeliveryBlazorApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddLocalization();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IConnectivityService, ConnectivityService>();
builder.Services.AddScoped<IErrorLogApi, MockErrorLogApi>();
builder.Services.AddScoped<IErrorLoggingService, ErrorLoggingService>();
builder.Services.AddScoped<IAuthApi, MockAuthApi>();
builder.Services.AddScoped<TokenAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<TokenAuthenticationStateProvider>());
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAddressBookService, MockAddressBookService>();
builder.Services.AddScoped<ICategoryService, MockCategoryService>();
builder.Services.AddScoped<IRestaurantService, MockRestaurantService>();
builder.Services.AddScoped<IPopularItemService, MockPopularItemService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddScoped<ILanguageApi, MockLanguageApi>();
builder.Services.AddScoped<ICultureService, CultureService>();
builder.Services.AddScoped<IThemeService, ThemeService>();
builder.Services.AddScoped<IAppUpdateService, AppUpdateService>();

await builder.Build().RunAsync();

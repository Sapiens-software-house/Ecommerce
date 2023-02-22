using Ecommerce.UI.Client;
using Ecommerce.UI.Client.Interface.IAuthService;
using Ecommerce.UI.Client.Services.AuthService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ecommerce.UI.Client.Ioc.IocHttp;
using Ecommerce.UI.Client.Services.ProductService;
using Ecommerce.UI.Client.Interface.IProductService;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();
Ioc.IocHttp(builder.Services);
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8082/") });

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
await builder.Build().RunAsync();

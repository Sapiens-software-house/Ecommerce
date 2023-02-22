using Ecommerce.UI.Client;
using Ecommerce.UI.Client.Interface.IAuthService;
using Ecommerce.UI.Client.Services.AuthService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ecommerce.UI.Client.Ioc.IocHttp;
using Ecommerce.UI.Client.Services.ProductService;
using Ecommerce.UI.Client.Interface.IProductService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Ioc.IocHttp(builder, builder.Services);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();

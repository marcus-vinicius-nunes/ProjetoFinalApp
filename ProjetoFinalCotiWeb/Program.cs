using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjetoFinalCotiWeb;
using ProjetoFinalCotiWeb.Helpers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5129/") });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<FornecedorHelper>();

await builder.Build().RunAsync();


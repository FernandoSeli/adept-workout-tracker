using Adept.Blazor;
using Adept.Data;
using MudBlazor.Services;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddDbContext<AdeptDatabaseContext>(options => options.UseSqlite($"Filename=app.db"));
//builder.Services.AddDbContextFactory<AdeptDatabaseContext>(options => options.UseSqlite($"Filename=app.db"));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


//var dbFactory = builder.Services.BuildServiceProvider().GetService<IDbContextFactory<AdeptDatabaseContext>>();

//var db = dbFactory?.CreateDbContext();

//var isCreated = db?.Database.EnsureCreated();

await builder.Build().RunAsync();

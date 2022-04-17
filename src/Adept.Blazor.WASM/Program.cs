using Adept.Blazor;
using Adept.Data;
using MudBlazor.Services;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Adept.Blazor.Services;
using Adept.Blazor.State;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

//builder.Services.AddDbContext<AdeptDatabaseContext>(options => options.UseSqlite($"Filename=app.db"));
builder.Services.AddDbContextFactory<AdeptDatabaseContext>(options => options.UseSqlite($"Filename=app.db"));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IRoutineService, RoutineService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IWorkoutTemplateService, WorkoutTemplateService>();
builder.Services.AddSingleton<RoutineState>();
var dbFactory = builder.Services.BuildServiceProvider().GetService<IDbContextFactory<AdeptDatabaseContext>>();

var db = dbFactory?.CreateDbContext();

var isCreated = db?.Database.EnsureCreated();

await builder.Build().RunAsync();


public partial class Program
{
    /// <summary>
    ///     FIXME: This is required for EF Core 6.0 as it is not compatible with trimming.
    ///     See https://github.com/dotnet/efcore/issues/26288 & https://github.com/dotnet/efcore/issues/26860
    /// </summary>
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    // ReSharper disable once UnusedMember.Local
    private static readonly Type s_keepDateOnly = typeof(DateOnly);
}
using Haihv.VBDLIS.TraCuu.App.Web.Components;
using TraCuu.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);
builder.AddDefaultHealthChecks();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapDefaultEndpoints();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(Haihv.VBDLIS.TraCuu.App.Shared._Imports).Assembly,
        typeof(Haihv.VBDLIS.TraCuu.App.Web.Client._Imports).Assembly);


app.Run();

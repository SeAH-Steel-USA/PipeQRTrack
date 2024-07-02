using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PipeQRTrack.Components;
using PipeQRTrack.Components.Account;
using PipeQRTrack.Data;
using MudBlazor.Services;
using PipeQRTrack.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

// Configure the AzureDbContext
var azureConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AzureDbContext>(options =>
    options.UseSqlServer(azureConnectionString));

// Configure the LocalDbContext
var localConnectionString = builder.Configuration.GetConnectionString("LocalConnection")
    ?? throw new InvalidOperationException("Connection string 'LocalConnection' not found.");
builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlServer(localConnectionString));

// Configure Identity
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AzureDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();


builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();


// my setup

builder.Services.AddMudServices();
builder.Services.AddScoped<BasicService>();
builder.Services.AddScoped<DataService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PipeQRTrack.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();

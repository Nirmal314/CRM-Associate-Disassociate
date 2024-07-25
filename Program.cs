using Microsoft.PowerPlatform.Dataverse.Client;

var builder = WebApplication.CreateBuilder(args);

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");

if (!File.Exists(dotenv))
    return;

foreach (var line in File.ReadAllLines(dotenv))
{
    var parts = line.Split(
        '=',
        StringSplitOptions.RemoveEmptyEntries);

    if (parts.Length != 2)
        continue;

    Environment.SetEnvironmentVariable(parts[0], parts[1]); 
}

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ServiceClient>(provider =>
{
    string clientId = Environment.GetEnvironmentVariable("ClientID")!;
    string clientSecret = Environment.GetEnvironmentVariable("ClientSecret")!;
    string url = Environment.GetEnvironmentVariable("CRMUrl")!;

    string connection = $"AuthType=ClientSecret;Url={url};ClientId={clientId};ClientSecret={clientSecret}";

    return new ServiceClient(connection);
});

var app = builder.Build();  

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Project}/{action=Index}/{id?}");

app.Run();

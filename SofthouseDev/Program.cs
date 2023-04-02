using SofthouseDev.Api;
using SofthouseDev.Services;
using SofthouseDev.Utilities;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddRazorPages();
    builder.Services.AddControllers();
    builder.Services.AddAuth();
    builder.Services.AddScoped<IGithubClient, GithubClient>();
    builder.Services.AddScoped<ISerializer, Serializer>();
}

var app = builder.Build();
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapRazorPages();
    app.MapControllers();

    app.Run();
}
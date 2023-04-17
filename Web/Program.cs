var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddRouting();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(c =>
{
    c.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    c.MapControllers();
});
app.Run();

public partial class Program { }

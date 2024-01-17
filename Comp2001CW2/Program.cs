using Microsoft.EntityFrameworkCore;
using Comp2001CW2.Data;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer("Server=dist-6-505.uopnet.plymouth.ac.uk;Database=COMP2001_LBrindle;User ID=LBrindle;Password=ErkZ744+;TrustServerCertificate=True;");
});

builder.Services.AddDataProtection()
        .SetApplicationName("YourApplicationName"); // Set a unique application name

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDistributedMemoryCache();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("./v1/swagger.json", "COMP2001 API");
});

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
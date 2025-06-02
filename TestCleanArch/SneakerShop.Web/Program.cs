using SneakerShop.Application.Services;
using SneakerShop.Domain.Repositories;
using SneakerShop.Infrastructure.Persistance;
using SneakerShop.Infrastructure.Services;
using SneakersShop.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISneakerRepository, SneakerRepository>();
builder.Services.AddScoped<ISneakerService, SneakerService>();
builder.Services.AddDbContext<SneakerDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
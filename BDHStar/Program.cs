using BDHStar.Models;
using BDHStar.Services;
using BHDStar.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BHDDatabaseSettings>(builder.Configuration.GetSection("BHD"));
builder.Services.AddSingleton<MovieService>();
builder.Services.AddSingleton<MovieTheatreService>();
builder.Services.AddSingleton<RoomService>();
builder.Services.AddSingleton<SessionService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

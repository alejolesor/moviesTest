using Movies.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Movies.Core.Repository;
using Movies.Infraestructure.Repository;
using Movies.Applications.UseCases.Movies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieUseCase, MovieUseCase>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

//setup
var connectionString = (builder.Configuration.GetConnectionString("SqlServerConnection"));
builder.Services.AddDbContext<ApiDbContext>(options =>
options.UseSqlServer(connectionString));

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

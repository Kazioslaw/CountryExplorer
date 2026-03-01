using System.Text.Json;
using CountryExplorer.Service;
using Microsoft.AspNetCore.Http.Json;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var countriesURL = "https://restcountries.com/";
builder.Services.AddScoped(x => new HttpClient { BaseAddress = new Uri(countriesURL) });
builder.Services.AddScoped<CountryService>();
builder.Services.AddCors(cors =>
{
	cors.AddPolicy("BlazorUIHTTPS", cors => cors
	.WithOrigins("https://localhost:7277", "https://countryexplorer-client.dev.localhost:7277")
	.AllowAnyHeader()
	.AllowCredentials());

	cors.AddPolicy("BlazorUIHTTP", cors => cors
	.WithOrigins("http://localhost:5133", "http://countryexplorer-client.dev.localhost:5133")
	.AllowAnyHeader()
	.AllowCredentials());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.MapScalarApiReference("/docs");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

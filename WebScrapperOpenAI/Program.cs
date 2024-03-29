using WebScrapperOpenAI.Business.Interfaces;
using WebScrapperOpenAI.Business;
using WebScrapperOpenAI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddChatGpt();

builder.Services.AddScoped<IWebScrapper,WebScrapperBusiness>();
builder.Services.AddScoped<IRandomNumberBusiness, RandomNumberBusiness>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

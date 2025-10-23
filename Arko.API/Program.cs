using Arko.API.Data;
using Arko.API.Endpoint;
using Arko.API.Handlers;
using Arko.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<ArkoDbContext>(x => { x.UseSqlServer(cnnStr); });

builder.Services.AddScoped<IEntryHandler, EntryHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(x =>
{
    x.CustomSchemaIds (n => n.FullName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseHttpsRedirection();


app.MapGet("/", () => new { message = "Ok" });
app.MapEndpoints();






app.Run();


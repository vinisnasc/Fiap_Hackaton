using Fiap_Hackaton.Health_Med.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwaggerConfiguration(app.Environment);
app.UseHttpsRedirection();
app.UseApiConfiguration(app.Environment);
app.MapControllers();
app.Run();
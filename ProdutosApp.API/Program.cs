using ProdutosApp.API.Extensions;
using ProdutosApp.Domain.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(config => { config.LowercaseUrls = true; });
builder.Services.AddSwaggerDoc();
builder.Services.AddCorsConfig();
builder.Services.AddAutoMapper(typeof(ProfileMap));
builder.Services.AddDependencyInjection(builder.Configuration);
builder.Services.AddMessagesConfig(builder.Configuration);

var app = builder.Build();

app.UseAuthorization();
app.UseSwaggerDoc();
app.UseCorsConfig();
app.MapControllers();
app.Run();

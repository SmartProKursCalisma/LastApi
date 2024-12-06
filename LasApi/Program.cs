using LasApi;
using LasApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped(typeof(ExampleFilter));
builder.Services.AddSwaggerGen();
builder.Services.AddCors(cfg =>
{
    cfg.AddPolicy("default", policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

builder.Services.AddSingleton(typeof(MockDataManager));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("default");
app.MapControllers();

app.Run();

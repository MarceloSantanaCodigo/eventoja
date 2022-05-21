using Dapper.Contrib.Extensions;
using EventosJa.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
         
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
});
});

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
SqlMapperExtensions.TableNameMapper = (type) => type.Name;

app.UseCors("AllowAll");
app.UseAuthorization();
app.UseMiddleware(typeof(AutenticacaoMiddleware));
app.MapControllers();

app.Run();

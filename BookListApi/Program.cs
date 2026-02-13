using BookListApi.Extensions;
using BookListApi.Model.Context;
using BookListApi.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddBookListService(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetService<BookListContext>();

    if (db is null) throw new InvalidOperationException(nameof(db));

    var service = scope.ServiceProvider.GetService<BookListService>();
    if (service is null) throw new InvalidCastException(nameof(service));
}



app.Run();

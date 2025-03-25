using Microsoft.EntityFrameworkCore;
using RentCar.data;
using Bogus;
using RentCar.models;
using System.Text;
using RentCar.Repository.Abstract;
using RentCar.Repository.Implementation;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
        options.UseMySql("server=localhost;user=root;password=admin;database=DbCarRent;",
            ServerVersion.AutoDetect("server=localhost;user=root;password=admin;database=DbCarRent;")));


builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

{
    app.UseSwagger();
    app.UseSwaggerUI();
}



using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
}


app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
               Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/Resources"
});
app.MapControllers();

app.Run();

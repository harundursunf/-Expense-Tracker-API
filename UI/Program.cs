using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Ef;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Controller'lar� ekle
builder.Services.AddControllers();

// Veritaban� ba�lant�s� (connection string appsettings.json i�inde)
builder.Services.AddDbContext<ExpenseDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Expense"),
        b => b.MigrationsAssembly("DataAccess")
    )
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            ClockSkew = TimeSpan.Zero
        }; 
    });


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>builder.RegisterModule(new AutoFacBusinessModule()));
// Swagger (dok�mantasyon arac�)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Sadece Development ortam�nda Swagger UI aktif olsun
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();// JWT do�rulamas� i�in gerekli middleware

app.UseAuthorization();//rollere g�re yetkilendirme

app.MapControllers();

app.Run();
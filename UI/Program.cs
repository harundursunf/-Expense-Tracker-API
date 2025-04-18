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

// Controller'larý ekle
builder.Services.AddControllers();

// Veritabaný baðlantýsý (connection string appsettings.json içinde)
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
// Swagger (dokümantasyon aracý)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Sadece Development ortamýnda Swagger UI aktif olsun
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();// JWT doðrulamasý için gerekli middleware

app.UseAuthorization();//rollere göre yetkilendirme

app.MapControllers();

app.Run();
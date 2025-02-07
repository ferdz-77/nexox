using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using nexox.Data;
using Nexox.Repositories;
using Nexox.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados usando MySQL Oficial
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34)) // Versão do MySQL Server
    ));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Nexox API",
        Version = "v1",
        Description = "Documentação da API Nexox.",
        Contact = new OpenApiContact
        {
            Name = "Equipe Nexox",
            Email = "suporte@nexox.com",
            Url = new Uri("https://github.com/ferdz-77/nexox")
        }
    });
});

builder.Services.AddScoped<IArtworkRepository, ArtworkRepository>();
builder.Services.AddScoped<IArtworkService, ArtworkService>();
builder.Services.AddScoped<ArtworkService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Ativar Swagger em ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nexox API v1");
        c.RoutePrefix = string.Empty; // Configura o Swagger como página inicial
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

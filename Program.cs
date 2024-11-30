using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PlatinumDriverAutos.Models;
using PlatinumDriverAutos.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura o contexto do banco de dados
builder.Services.AddDbContext<PlatinumDriveContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("PlatinumDriveDB"),
        new MySqlServerVersion(new Version(8, 0, 27)) // Vers�o do MySQL instalada no seu ambiente
    ));

// Adicionar servi�os ao cont�iner.
builder.Services.AddControllersWithViews();

// Configurar a sess�o
builder.Services.AddDistributedMemoryCache(); // Usado para armazenar sess�es na mem�ria
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expira��o da sess�o
    options.Cookie.HttpOnly = true; // Impede o acesso � sess�o pelo JavaScript
    options.Cookie.IsEssential = true; // A sess�o � essencial para o funcionamento do site
});

// Adicionar IHttpContextAccessor para permitir acesso ao contexto HTTP
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configurar o pipeline de requisi��o HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padr�o do HSTS � 30 dias. Pode ser alterado conforme necessidade para produ��o.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Usar a sess�o no pipeline
app.UseSession();

app.UseRouting();

app.UseAuthorization();

// Mapear a rota padr�o
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

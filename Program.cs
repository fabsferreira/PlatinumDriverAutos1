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
        new MySqlServerVersion(new Version(8, 0, 27)) // Versão do MySQL instalada no seu ambiente
    ));

// Adicionar serviços ao contêiner.
builder.Services.AddControllersWithViews();

// Configurar a sessão
builder.Services.AddDistributedMemoryCache(); // Usado para armazenar sessões na memória
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expiração da sessão
    options.Cookie.HttpOnly = true; // Impede o acesso à sessão pelo JavaScript
    options.Cookie.IsEssential = true; // A sessão é essencial para o funcionamento do site
});

// Adicionar IHttpContextAccessor para permitir acesso ao contexto HTTP
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // O valor padrão do HSTS é 30 dias. Pode ser alterado conforme necessidade para produção.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Usar a sessão no pipeline
app.UseSession();

app.UseRouting();

app.UseAuthorization();

// Mapear a rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

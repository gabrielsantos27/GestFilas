using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetoBacharelatoFilas.Context;
using ProjetoBacharelatoFilas.Identity;
using ProjetoBacharelatoFilas.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IPedidoServicoRepository, PedidoServicoRepository>();
builder.Services.AddScoped<IAtendimentoPedidoRepository, AtendimentoPedidoRepository>();
builder.Services.AddScoped<IEstudanteRepository, EstudanteRepository>();
builder.Services.AddScoped<IAuthenticate, AutenticaoService>();
builder.Services.AddIdentity<AspNetUser, IdentityRole>().
AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
builder.Services.AddScoped<IModeloSenhaRepository, ModeloSenhaRepository>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();


builder.Services.ConfigureApplicationCookie(opt => opt.AccessDeniedPath = "/Account/Login");



builder.Services.AddDbContext<AppDbContext>(c => c.UseSqlServer(connectionString));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.SeedData();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();





using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Providers;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

//Configurando conexão com o BD
//builder.Services.AddConectionBD(mySqlConnection);

//Adicionando as dependências
builder.Services.AddDIPScoppedClasse();
builder.Services.AddDIPSingletonClasse();
builder.Services.AddDIPTransientClasse();

//Configurando referência ciclica com JsonIgnore
builder.Services.AddConfigurationJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Rota de navegação padrão, ou seja, caso eu não digite nada, essa vai ser a rota 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

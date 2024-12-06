using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Providers;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

//Configurando conex�o com o BD
builder.Services.AddConectionBD(mySqlConnection);

//Adicionando as depend�ncias
builder.Services.AddDIPScoppedClasse();
builder.Services.AddDIPSingletonClasse();
builder.Services.AddDIPTransientClasse();

//Configurando refer�ncia ciclica com JsonIgnore
builder.Services.AddConfigurationJson();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeding = scope.ServiceProvider.GetRequiredService<SeedingService>();
    // Agora voc� pode usar a inst�ncia de 'SeedingService'
    seeding.Seeding();
}

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

//Rota de navega��o padr�o, ou seja, caso eu n�o digite nada, essa vai ser a rota 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

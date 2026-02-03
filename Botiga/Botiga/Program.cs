using Botiga.EndPoints;
using Botiga.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configuració
builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Connexió a la base de dades
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
DatabaseConnection dbConn = new DatabaseConnection(connectionString);

// 👇 Afegim els serveis de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 👇 Activem Swagger només en desenvolupament (opcional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

// Registra els endpoints
app.MapProductEndpoints(dbConn);
app.MapCarrosEndpoints(dbConn);
app.MapFamiliaEndpoints(dbConn);
app.MapCarroDeLaCompraEndpoints(dbConn); // si en tens un per al carro de la compra
app.MapCompraEndpoints(dbConn);

app.Run();

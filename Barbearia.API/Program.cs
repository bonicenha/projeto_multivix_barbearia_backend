using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Barbearia.Aplicacao.Servicos.Profiles;
using Barbearia.Aplicacao.Servicos.Servicos;
using Barbearia.Dominio.Servicos.Servicos;
using Barberia.Infra.Servicos.Mapeamentos;
using Barberia.Infra.Servicos.Repositorios;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.OpenApi.Models;
using NHibernate;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(op =>
{
    op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    op.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Barbearia", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header usando o esquemma Bearer."
    });
});


builder.Services.AddSingleton<ISessionFactory>(factory =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure()
    .Database((MySQLConfiguration.Standard.ConnectionString(connectionString)
    .FormatSql()
    .ShowSql()))
    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ServicoMap>())
    .BuildSessionFactory();
});
builder.Services.AddScoped<NHibernate.ISession>(factory => factory.GetService<ISessionFactory>()!.OpenSession());
builder.Services.AddScoped<ITransaction>(factory => factory.GetService<ISession>()!.BeginTransaction());

builder.Services.AddAutoMapper(typeof(ServicoProfile));
builder.Services.Scan(scan => scan
    .FromAssemblyOf<ServicosAppServico>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ServicosServico>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ServicosRepositorio>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

var chave = Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "SistemaFinanceiro");
                c.DisplayRequestDuration();
            });
}

var cliente = "http://localhost:4200";
app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(cliente));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
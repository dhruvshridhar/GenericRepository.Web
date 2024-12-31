using GenericRepository.Web.Database;
using Microsoft.EntityFrameworkCore;
using GenericRepository.Web.Middlewares;
using GenericRepository.Web.Services;
using GenericRepository.Web.Tenant;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding Tenant related services
builder.Services.AddScoped<ITenantProvider, TenantProvider>();
builder.Services.AddSingleton<ITenantDatabaseService, TenantDatabaseService>();

// Adding generic DbContext which can be used for both Postgres and Mongo
// builder.Services.AddEntityFrameworkNpgsql().AddDbContext<PostgresDbContext>(options =>
// {
//     options.UseNpgsql(builder.Configuration.GetConnectionString("postgres"));
// });

builder.Services.AddScoped<DbContext>(serviceProvider =>
{
    // Get Tenant related info
    var tenantProvider = serviceProvider.GetRequiredService<ITenantProvider>();
    var tenantDatabaseService = serviceProvider.GetRequiredService<ITenantDatabaseService>();
    var tenantConfig = tenantDatabaseService.GetConfigForTenant(tenantProvider.GetTenant());

    var optionsBuilder = new DbContextOptionsBuilder();
    switch (tenantConfig.DbType)
    {
        case DatabaseType.Postgres:
            optionsBuilder.UseNpgsql(tenantConfig.ConnectionString);
            return new PostgresDbContext(optionsBuilder.Options);
        case DatabaseType.Mongo:
            optionsBuilder.UseMongoDB(tenantConfig.ConnectionString, tenantConfig.DatabaseName!);
            return new MongoDbContext(optionsBuilder.Options);
        default:
            throw new InvalidOperationException("Unsupported database type.");
    }
});

// Add DataService
builder.Services.AddScoped(typeof(IDataService<>), typeof(DataService<>));

// Add Tenant Middleware
builder.Services.AddTransient<TenantMiddleware>();

//Default Dotnet DI Container
//builder.Services.AddScoped<IGenericRepository<Book>, BookRepository>();
//builder.Services.AddScoped<IGenericRepository<Author>, AuthorRepository>();

//Using AutoFac
// var containerBuilder = new ContainerBuilder();
// containerBuilder.RegisterAssemblyTypes(typeof(IGenericRepository<>).Assembly).AsClosedTypesOf(typeof(IGenericRepository<>)).AsImplementedInterfaces();
// containerBuilder.Populate(builder.Services);
// var container = containerBuilder.Build();
// builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
// {
//     options.RegisterInstance(container);
// }));

var app = builder.Build();

// Use tenant middleware
app.UseMiddleware<TenantMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


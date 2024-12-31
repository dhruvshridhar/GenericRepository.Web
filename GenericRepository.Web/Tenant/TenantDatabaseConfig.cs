namespace GenericRepository.Web.Tenant;

public enum DatabaseType
{
    Postgres,
    Mongo
}

public class TenantDatabaseConfig
{
    public DatabaseType DbType { get; set; }
    public string ConnectionString { get; set; } = null!;
    public string? DatabaseName { get; set; } // For MongoDB
}

public interface ITenantDatabaseService
{
    TenantDatabaseConfig GetConfigForTenant(string tenantName);
}

public class TenantDatabaseService : ITenantDatabaseService
{
    private readonly IConfiguration _configuration;

    public TenantDatabaseService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public TenantDatabaseConfig GetConfigForTenant(string tenantName)
    {
        var configSection = _configuration.GetSection($"Tenants:{tenantName}");
        var dbType = configSection.GetValue<string>("DbType") == Enum.GetName(typeof(DatabaseType), DatabaseType.Postgres)
            ? DatabaseType.Postgres
            : DatabaseType.Mongo;

        return new TenantDatabaseConfig
        {
            ConnectionString = configSection.GetValue<string>("ConnectionString") ?? string.Empty,
            DatabaseName = configSection.GetValue<string>("DatabaseName"),
            DbType = dbType
        };
    }
}
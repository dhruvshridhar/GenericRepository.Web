namespace GenericRepository.Web.Tenant;

public interface ITenantProvider
{
    public string GetTenant();
    public void SetTenant(string tenantName);
}

public class TenantProvider : ITenantProvider
{
    private string _tenant = null!;

    public string GetTenant()
    {
        return _tenant;
    }

    public void SetTenant(string tenantName)
    {
        _tenant = tenantName;
    }
}
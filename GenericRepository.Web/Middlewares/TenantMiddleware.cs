using GenericRepository.Web.Tenant;

namespace GenericRepository.Web.Middlewares;

public class TenantMiddleware : IMiddleware
{
    private readonly ITenantProvider _tenantProvider;
    public TenantMiddleware(ITenantProvider tenantProvider)
    {
        _tenantProvider = tenantProvider;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Path.ToString().Contains("swagger"))
        {
            var tenantName = context.Request.Query["tenant"].ToString();

            if (string.IsNullOrEmpty(tenantName))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Tenant Name is required.");
                return;
            }
        
            _tenantProvider.SetTenant(tenantName);
            await next(context);
        }
    }
}
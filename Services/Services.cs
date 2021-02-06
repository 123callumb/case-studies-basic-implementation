using Microsoft.Extensions.DependencyInjection;
using Services.AuthenticationManagement;
using Services.AuthenticationManagement.Implementation;
using Services.EntityFramework;
using Services.EntityFramework.DbEntities;
using Services.GenericRepository;
using Services.GenericRepository.Implementation;
using Services.VendorItemManagement;
using Services.VendorItemManagement.Implementation;

namespace Services
{
    public static class Services
    {
        public static void RegisterServices(this IServiceCollection svr)
        {
            svr.AddScoped<IDatabaseContext, DatabaseContext>();
            svr.AddScoped<IGenericQuerier, GenericQuerier>();
            svr.AddScoped<IGenericRepo, GenericRepo>();
            svr.AddScoped<IAuthenticationManager, AuthenticationManager>();
            svr.AddScoped<IVendorItemManager, VendorItemManager>();
        }
    }
}

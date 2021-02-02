using Microsoft.EntityFrameworkCore;
using Services.EntityFramework.DbEntities;
using System.Threading;
using System.Threading.Tasks;

namespace Services.EntityFramework
{
    public interface IDatabaseContext
    {
        DbSet<Quote> Quotes { get; set; }
        DbSet<QuoteResponse> QuoteResponses { get; set; }
        DbSet<QuoteStatus> QuoteStatuses { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Vendor> Vendors { get; set; }
        DbSet<VendorItem> VendorItems { get; set; }
        DbSet<VendorUser> VendorUsers { get; set; }

        // These two methods are extracted from DbContext class
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}

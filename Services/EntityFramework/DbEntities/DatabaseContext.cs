using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Services.EntityFramework.DbEntities
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<QuoteResponse> QuoteResponses { get; set; }
        public virtual DbSet<QuoteStatus> QuoteStatuses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorItem> VendorItems { get; set; }
        public virtual DbSet<VendorUser> VendorUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=cs_implementation_db", x => x.ServerVersion("10.4.17-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quote");

                entity.HasIndex(e => e.VendorItemId, "FK_Quote_Vendor_Item");

                entity.Property(e => e.QuoteId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuoteID");

                entity.Property(e => e.QuantityRequested)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.QuoteDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.Property(e => e.VendorItemId)
                    .HasColumnType("int(11)")
                    .HasColumnName("VendorItemID");

                entity.HasOne(d => d.VendorItem)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.VendorItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_Vendor_Item");
            });

            modelBuilder.Entity<QuoteResponse>(entity =>
            {
                entity.ToTable("quote_response");

                entity.HasIndex(e => e.QuoteId, "FK_Quote_Quote_Response");

                entity.HasIndex(e => e.QuoteStatusId, "FK_Quote_Reponse_Status");

                entity.Property(e => e.QuoteResponseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuoteResponseID");

                entity.Property(e => e.QuoteId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuoteID");

                entity.Property(e => e.QuoteStatusId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuoteStatusID")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ReponseText)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ResponseDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("current_timestamp()");

                entity.HasOne(d => d.QuoteNavigation)
                    .WithMany(p => p.QuoteResponses)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_Quote_Response");

                entity.HasOne(d => d.QuoteStatus)
                    .WithMany(p => p.QuoteResponses)
                    .HasForeignKey(d => d.QuoteStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_Reponse_Status");
            });

            modelBuilder.Entity<QuoteStatus>(entity =>
            {
                entity.ToTable("quote_status");

                entity.Property(e => e.QuoteStatusId)
                    .HasColumnType("int(11)")
                    .HasColumnName("QuoteStatusID");

                entity.Property(e => e.Colour)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'#66d17f'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.RoleId, "FK_User_RoleID");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("UserID");

                entity.Property(e => e.CompanyEmail)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_RoleID");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.Property(e => e.VendorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("VendorID");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("'0'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<VendorItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("vendor_item");

                entity.HasIndex(e => e.VendorId, "FK_Item_Vendor");

                entity.Property(e => e.ItemId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ItemID");

                entity.Property(e => e.ItemDescription)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ItemImageUrl)
                    .HasColumnType("varchar(1000)")
                    .HasColumnName("ItemImageURL")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.VendorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("VendorID");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.VendorItems)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Item_Vendor");
            });

            modelBuilder.Entity<VendorUser>(entity =>
            {
                entity.ToTable("vendor_user");

                entity.HasIndex(e => e.VendorId, "FK_Vendor_User_Vendor");

                entity.Property(e => e.VendorUserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("VendorUserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.VendorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("VendorID");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.VendorUsers)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vendor_User_Vendor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

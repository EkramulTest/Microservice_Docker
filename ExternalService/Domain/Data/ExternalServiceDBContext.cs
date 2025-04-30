using ExternalService.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ExternalService.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
namespace ExternalService.Domain.Data
{
    public class ExternalServiceDBContext : DbContext
    {
        public ExternalServiceDBContext(DbContextOptions<ExternalServiceDBContext> options) : base(options)
        {

        }

        public virtual DbSet<ExternalTicketConfig> ExternalTicketConfigg { get; set; } = null!;
        public virtual DbSet<ExternTicketCustomFields> ExternTicketCustomFieldss { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExternalTicketConfig>(entity =>
            {
                entity.ToTable("ExternalTicketConfig");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.CompanyId).HasColumnName("CompanyId");
                entity.Property(e => e.ProjectId).HasColumnName("ProjectId");
                entity.Property(e => e.BaseUrl).HasColumnName("BaseUrl");
                entity.Property(e => e.UserEmail).HasColumnName("UserEmail");
                entity.Property(e => e.ApiToken).HasColumnName("ApiToken");
                entity.Property(e => e.ProjectKey).HasColumnName("ProjectKey");
                entity.Property(e => e.MasterTicketingToolId).HasColumnName("MasterTicketingToolId");
                entity.Property(e => e.IsActive).HasColumnName("IsActive");
            });

            modelBuilder.Entity<ExternTicketCustomFields>(entity =>
            {
                entity.ToTable("ExternTicketCustomFields");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.CompanyId).HasColumnName("CompanyId");
                entity.Property(e => e.ProjectId).HasColumnName("ProjectId");
                entity.Property(e => e.ExternalTicketConfigId).HasColumnName("ExternalTicketConfigId");
                entity.Property(e => e.CustomFieldId).HasColumnName("CustomFieldId");
                entity.Property(e => e.IsActive).HasColumnName("IsActive");
            });
        }
    }
}

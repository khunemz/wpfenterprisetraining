using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using FriendOrganize.Model;

namespace FriendOrganize.DataAccess
{
    public class FriendOrganizeDbContext : DbContext
    {
        public FriendOrganizeDbContext() :base("FriendOrganizeDb")
        {
            
        }
        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new FriendConfiguration());

        }
    }

    public class FriendConfiguration : EntityTypeConfiguration<Friend>
    {
        public FriendConfiguration()
        {
            Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

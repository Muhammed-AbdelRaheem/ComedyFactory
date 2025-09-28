using Data.Service;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class WriteDbContextFactory : IDesignTimeDbContextFactory<WriteDbContext>
    {
        public WriteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WriteDbContext>();
            //optionsBuilder.UseNpgsql(Config.Write_DefaultConnection);
            optionsBuilder.UseSqlServer(Config.Write_DefaultConnection);

            return new WriteDbContext(optionsBuilder.Options);
        }
    }
    public class ApplicationDbContext : IdentityDbContext<
    ApplicationUser, ApplicationRole, string,
    IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {




        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        //public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Desire> Desires { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<ApiClient> ApiClient { get; set; }
        public DbSet<ErrorMessage> ErrorMessages { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<MasterCategory> MasterCategories { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Activities> Activities { get; set; }

     


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseIdentityColumns();


            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;


            builder.Entity<ApplicationUser>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Country>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<City>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Nationality>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Block>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Configuration>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<ApiClient>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<ErrorMessage>().HasQueryFilter(x => !x.Deleted);
            builder.Entity<Log>().HasQueryFilter(x => !x.Deleted);


       

            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();
            });


            builder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

        }



    }


    public class WriteDbContext : ApplicationDbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }
 
    }

    public class ReadDBContext : ApplicationDbContext
    {
        public ReadDBContext()
        {

        }
        public ReadDBContext(DbContextOptions<ReadDBContext> options) : base(options)
        {

        }
        [Obsolete("This context is read-only", true)]
        public new int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new int SaveChanges(bool acceptAll)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }

        [Obsolete("This context is read-only", true)]
        public new Task<int> SaveChangesAsync(bool acceptAll, CancellationToken token = default)
        {
            throw new InvalidOperationException("This context is read-only.");
        }


    }
}
using AspNetCore3WebApi.Data.Entities;
using AspNetCore3WebApi.Data.Migrations;
using System.Data.Entity;

namespace AspNetCore3WebApi.Data
{
  public class CampContext : DbContext
  {
    public CampContext() : base("DefaultConnection")
    {
      Database.SetInitializer(new MigrateDatabaseToLatestVersion<CampContext, Configuration>());
    }

    public DbSet<Camp> Camps { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Talk> Talks { get; set; }

  }
}

using AspNetCore3WebApi.Data.Entities;
using AspNetCore3WebApi.Service;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AspNetCore3WebApi.Data.Migrations
{

  internal sealed class Configuration : DbMigrationsConfiguration<CampContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
      ContextKey = "AspNetCore3WebApi.Data.CampContext";
    }

    protected override void Seed(CampContext ctx)
    {
      if (!ctx.Camps.Any())
      {
        ctx.Camps.AddOrUpdate(x => x.CampId,
          new Camp()
          {
            CampId = Ulid.NewUlid().ToString(),
            Moniker = "ATL2018",
            Name = "Atlanta Code Camp",
            EventDate = new DateTime(2018, 10, 18),
            Location = new Location()
            {
              VenueName = "Atlanta Convention Center",
              Address1 = "123 Main Street",
              CityTown = "Atlanta",
              StateProvince = "GA",
              PostalCode = "12345",
              Country = "USA"
            },
            Length = 1,
            Talks = new Talk[]
            {
            new Talk
            {
              TalkId = Ulid.NewUlid().ToString(),
              Title = "Entity Framework From Scratch",
              Abstract = "Entity Framework from scratch in an hour. Probably cover it all",
              Level = 100,
              Speaker = new Speaker
              {
                SpeakerId = Ulid.NewUlid().ToString(),
                FirstName = "Thomas",
                LastName = "Cayne",
                BlogUrl = "http://slashand.com",
                Company = "slashand LLC",
                CompanyUrl = "http://slashand.com",
                GitHub = "thomascayne",
                Twitter = "thomascayne"
              }
            },
            new Talk
            {
              TalkId = Ulid.NewUlid().ToString(),
              Title = "Writing Sample Data Made Easy",
              Abstract = "Thinking of good sample data examples is tiring.",
              Level = 200,
              Speaker = new Speaker
              {
                SpeakerId = Ulid.NewUlid().ToString(),
                FirstName = "Pedro",
                LastName = "Cayne",
                BlogUrl = "http://slashand.com",
                Company = "slashand LLC",
                CompanyUrl = "http://slashand.com",
                GitHub = "pedrocayne",
                Twitter = "pedrocayne"
              }
            }
            }
          });
      }
    }
  }
}

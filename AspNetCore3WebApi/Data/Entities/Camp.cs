using System;
using System.Collections.Generic;

namespace AspNetCore3WebApi.Data.Entities
{
  public class Camp
  {
    public string CampId { get; set; }
    public DateTime EventDate { get; set; } = DateTime.MinValue;
    public int Length { get; set; } = 1;
    public string Name { get; set; }
    public Location Location { get; set; }
    public string Moniker { get; set; }
    public ICollection<Talk> Talks { get; set; }
  }
}
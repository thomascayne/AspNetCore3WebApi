using System;

namespace AspNetCore3WebApi.Provider
{
  public interface IDateTimeProvider
  {
    DateTimeOffset UtcNow { get; }
  }
}

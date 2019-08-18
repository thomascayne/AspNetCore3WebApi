using System.Threading.Tasks;

namespace AspNetCore3WebApi.Infrastructure.Query
{
  #region Interfaces

  /// <summary>
  /// Defines the <see cref="IQueryProcessor" /> interface
  /// </summary>
  public interface IQueryProcessor
  {
    #region |Methods|

    /// <summary>
    /// The Process finds the correct query handler to serve the request
    /// </summary>
    /// <typeparam name="TResult">The generic return type</typeparam>
    /// <param name="query">The query object</param>
    /// <returns>The data that is returned by query handler</returns>
    TResult Process<TResult>(IQueryEntity<TResult> query);

    /// <summary>
    /// The Process finds the correct query handler to serve the request
    /// </summary>
    /// <typeparam name="TResult">The generic return type</typeparam>
    /// <param name="query">The query object</param>
    /// <returns>The data that is returned by query handler</returns>
    Task<TResult> ProcessAsync<TResult>(IQueryEntity<TResult> query);

    #endregion
  }

  #endregion

}

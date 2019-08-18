using System.Threading.Tasks;

namespace AspNetCore3WebApi.Infrastructure.Query
{
  /// <summary>
  /// Defines the <see cref="IAsyncQueryHandler{in TQuery, TResult}" /> interface
  /// </summary>
  /// <typeparam name="TQuery">The generic query type</typeparam>
  /// <typeparam name="TResult">The generic result type</typeparam>
  public interface IAsyncQueryHandler<in TQuery, TResult> where TQuery : IQueryEntity<TResult>
  {
    #region |Methods|

    /// <summary>
    /// The ExecuteAsync
    /// </summary>
    /// <param name="query">The query object</param>
    /// <returns>The awaitable task</returns>
    Task<TResult> ExecuteAsync(TQuery query);

    #endregion
  }

}

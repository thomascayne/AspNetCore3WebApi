using System.Threading.Tasks;

namespace AspNetCore3WebApi.Infrastructure.Command
{

  #region Interfaces

  /// <summary>
  /// Defines the <see cref="ICommandPreConditionAsync{in TCommand}" /> interface
  /// </summary>
  /// <typeparam name="TCommand">The generic command type</typeparam>
  public interface ICommandPreConditionAsync<in TCommand> where TCommand : ICommandEntity
  {
    #region |Methods|

    /// <summary>
    /// The method that does data validation before committing data modification into data store
    /// </summary>
    /// <param name="command">The command that has to be validated</param>
    /// <returns>The awaitable task</returns>
    Task ValidateAsync(TCommand command);

    #endregion
  }

  /// <summary>
  /// Defines the <see cref="ICommandPreCondition{in TCommand}" /> interface
  /// </summary>
  /// <typeparam name="TCommand">The generic command type</typeparam>
  public interface ICommandPreCondition<in TCommand> where TCommand : ICommandEntity
  {
    #region |Methods|

    /// <summary>
    /// The method that does data validation before committing data modification into data store
    /// </summary>
    /// <param name="command">The command that has to be validated</param>
    void Validate(TCommand command);

    #endregion
  }

  #endregion

}

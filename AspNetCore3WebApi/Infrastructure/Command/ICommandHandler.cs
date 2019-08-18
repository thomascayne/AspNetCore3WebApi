using System.Threading.Tasks;

namespace AspNetCore3WebApi.Infrastructure.Command
{

  #region Interfaces

  /// <summary>
  /// Defines the <see cref="ICommandHandlerAsync" /> interface
  /// </summary>
  public interface ICommandHandlerAsync
  {
  }

  /// <summary>
  /// Defines the <see cref="ICommandHandlerAsync{in TCommand}" /> interface
  /// </summary>
  /// <typeparam name="TCommand">The generic command type</typeparam>
  public interface ICommandHandlerAsync<in TCommand> : ICommandHandlerAsync
      where TCommand : ICommandEntity
  {
    #region |Methods|

    /// <summary>
    /// The method that handles data modification operation
    /// </summary>
    /// <param name="command">The command that has data modification details</param>
    /// <returns>The awaitable task</returns>
    Task HandleAsync(TCommand command);

    #endregion
  }

  /// <summary>
  /// Defines the <see cref="ICommandHandlerAsync{in TCommand, TReturn}" /> interface
  /// </summary>
  /// <typeparam name="TCommand">The generic command type</typeparam>
  /// <typeparam name="TReturn">The genetic type of return data</typeparam>
  public interface ICommandHandlerAsync<in TCommand, TReturn> : ICommandHandlerAsync
      where TCommand : ICommandEntity
  {
    #region |Methods|

    /// <summary>
    /// The method that handles data modification operation
    /// </summary>
    /// <param name="command">The command that has data modification details</param>
    /// <returns>The awaitable task</returns>
    Task<TReturn> HandleAsync(TCommand command);

    #endregion
  }

  /// <summary>
  /// Defines the <see cref="ICommandHandler" /> interface
  /// </summary>
  public interface ICommandHandler
  {
  }

  /// <summary>
  /// Defines the <see cref="ICommandHandler{in TCommand}" /> interface
  /// </summary>
  /// <typeparam name="TCommand"></typeparam>
  public interface ICommandHandler<in TCommand> : ICommandHandler
      where TCommand : ICommandEntity
  {
    #region |Methods|

    /// <summary>
    /// The method that handles data modification operation
    /// </summary>
    /// <param name="command">The command that has data modification details</param>
    void Handle(TCommand command);

    #endregion
  }

  /// <summary>
  /// Defines the <see cref="ICommandHandler{in TCommand, out TReturn}" />
  /// </summary>
  /// <typeparam name="TCommand"></typeparam>
  /// <typeparam name="TReturn"></typeparam>
  public interface ICommandHandler<in TCommand, out TReturn> : ICommandHandler
      where TCommand : ICommandEntity
  {
    #region |Methods|

    /// <summary>
    /// The method that handles data modification operation
    /// </summary>
    /// <param name="command">The command that has data modification details</param>
    /// <returns>The data to be returned after execution</returns>
    TReturn Handle(TCommand command);

    #endregion
  }

  #endregion

}

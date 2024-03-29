﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AspNetCore3WebApi.Infrastructure.Extension
{
  /// <summary>
  /// Defines the <see cref="ServiceCollectionExtensions" /> class
  /// </summary>
  public static class ServiceCollectionExtensions
  {
    #region |Methods|

    /// <summary>
    /// The GetTypesAssignableTo
    /// </summary>
    /// <param name="assembly">The assembly</param>
    /// <param name="compareType">The generic interface type information</param>
    /// <returns>The <see cref="List{TypeInfo}"/> that has implemented classes type info</returns>
    public static List<TypeInfo> GetTypesAssignableTo(this Assembly assembly, Type compareType)
    {
      var typeInfoList = assembly.DefinedTypes.Where(x => x.IsClass
                          && !x.IsAbstract
                          && x != compareType
                          && x.GetInterfaces()
                                  .Any(i => i.IsGenericType
                                          && i.GetGenericTypeDefinition() == compareType))?.ToList();

      return typeInfoList;
    }

    /// <summary>
    /// The method that adds all the classes inherited from the generic interface type as specific implemented interface
    /// </summary>
    /// <param name="services">The services collection object</param>
    /// <param name="assemblyString">The assembly name where the implementation resides</param>
    /// <param name="compareType">The generic interface type information</param>
    /// <param name="lifetime">The service lifetime information, default it will be scoped</param>
    public static void AddClassesAsImplementedInterface(
        this IServiceCollection services,
        string assemblyString,
        Type compareType,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
      AddClassesAsImplementedInterface(services, Assembly.Load(assemblyString), compareType, lifetime);
    }

    /// <summary>
    /// The method that adds all the classes inherited from the generic interface type as specific implemented interface
    /// </summary>
    /// <param name="services">The services collection object</param>
    /// <param name="assembly">The assembly that has implementations detail</param>
    /// <param name="compareType">The generic interface type information</param>
    /// <param name="lifetime">The service lifetime information, default it will be scoped</param>
    public static void AddClassesAsImplementedInterface(
        this IServiceCollection services,
        Assembly assembly,
        Type compareType,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
      assembly.GetTypesAssignableTo(compareType).ForEach((t) =>
      {
        foreach (var implementedInterface in t.ImplementedInterfaces)
        {
          switch (lifetime)
          {
            case ServiceLifetime.Scoped:
              services.AddScoped(implementedInterface, t);
              break;
            case ServiceLifetime.Singleton:
              services.AddSingleton(implementedInterface, t);
              break;
            case ServiceLifetime.Transient:
              services.AddTransient(implementedInterface, t);
              break;
          }
        }
      });
    }

    /// <summary>
    /// The method that adds all the classes inherited from the generic interface type as specific implemented interface
    /// </summary>
    /// <param name="services">The services collection object</param>
    /// <param name="assemblyString">The assembly name where the implementation resides</param>
    /// <param name="compareType">The generic interface type information</param>
    /// <param name="action">The action<see cref="Action{Type, Type}"/> that has to be executed</param>
    public static void AddClassesAsImplementedInterface(this IServiceCollection services, string assemblyString, Type compareType, Action<Type, Type> action)
    {
      AddClassesAsImplementedInterface(services, Assembly.Load(assemblyString), compareType, action);
    }

    /// <summary>
    /// The method that adds all the classes inherited from the generic interface type as specific implemented interface
    /// </summary>
    /// <param name="services">The services collection object</param>
    /// <param name="assembly">The assembly that has implementations detail</param>
    /// <param name="compareType">The generic interface type information</param>
    /// <param name="action">The action<see cref="Action{Type, Type}"/> that has to be executed</param>
    public static void AddClassesAsImplementedInterface(this IServiceCollection services, Assembly assembly, Type compareType, Action<Type, Type> action)
    {
      assembly.GetTypesAssignableTo(compareType).ForEach((t) =>
      {
        foreach (var implementedInterface in t.ImplementedInterfaces)
        {
          action(implementedInterface, t);
        }
      });
    }

    #endregion
  }

}

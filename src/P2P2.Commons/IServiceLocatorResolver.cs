using System;
using System.Collections;
using System.Collections.Generic;

namespace P2P2.Commons
{
    /// <summary>
    /// Defines service locator.
    /// </summary>
    public interface IServiceLocatorResolver
    {
        IEnumerable<T> GetAllInstances<T>();
        IEnumerable GetAllInstances(Type type);
        T GetInstance<T>();
        object GetInstance(Type type);
        T TryGetInstance<T>();
        object TryGetInstance(Type type);
    }
}

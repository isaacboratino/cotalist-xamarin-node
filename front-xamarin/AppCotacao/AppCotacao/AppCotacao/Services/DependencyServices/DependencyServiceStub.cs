using System;
using System.Collections.Generic;

namespace AppCotacao.Services.DependencyServices
{
    public class DependencyServiceStub : IDependencyService
    {
        private readonly Dictionary<Type, object> registeredServices = new Dictionary<Type, object>();

        public T Get<T>() where T : class
        {
            return (T)registeredServices[typeof(T)];
        }

        public void Register<T>(T impl) where T : class
        {
            this.registeredServices[typeof(T)] = impl;
        }
    }
}

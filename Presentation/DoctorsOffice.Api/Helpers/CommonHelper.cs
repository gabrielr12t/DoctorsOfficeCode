using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DoctorsOffice.Api.Helpers
{
    public class CommonHelper
    {
        public static IEnumerable<T> GetImplementationsFromType<T>(T type) where T : class
        {
            return from t in Assembly.GetExecutingAssembly().GetTypes()
                   where t.GetInterfaces().Contains(typeof(T))
                            && t.GetConstructor(Type.EmptyTypes) != null
                   select Activator.CreateInstance(t) as T;
        }
    }
}

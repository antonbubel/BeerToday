namespace BeerToday.Utilities.Common.Extensions
{
    using System;
    using System.Linq;

    public static class TypeExtensions
    {
        public static bool ImplementGenericInterface(this Type type, Type genericInterfaceType)
        {
            return type.GetInterfaces()
                .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == genericInterfaceType);
        }
    }
}


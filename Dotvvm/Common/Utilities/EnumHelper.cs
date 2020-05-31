using System;

namespace Common.Utilities
{
    public static class EnumHelper
    {
        public static T FromString<T>(string value) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}

using System.Reflection;

namespace Monpoke.Tests
{
    public static class ReflectionExtensions
    {
        public static void SetField(this object obj, string fieldName, object value)
        {
            var type = obj.GetType();
            var field = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

            field.SetValue(obj, value);
        }
    }
}

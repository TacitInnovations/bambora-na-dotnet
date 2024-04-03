using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;

namespace Bambora.NA.SDK
{
    public class PaymentMethodsStringEnumConverter : Newtonsoft.Json.Converters.StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is PaymentMethods)
            {
                var fi = value.GetType().GetField(value.ToString());
                var attribute = fi.GetCustomAttribute<DescriptionAttribute>();
                writer.WriteValue(attribute != null ? attribute.Description : value.ToString());
            }
            else
            {
                base.WriteJson(writer, value, serializer);
            }
        }
    }
}
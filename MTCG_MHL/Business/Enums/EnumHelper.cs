using System.ComponentModel;
using System.Reflection;

namespace MTCG_MHL.Business.Enums;

public class EnumHelper
{
    public static string GetDescription(Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());
        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}
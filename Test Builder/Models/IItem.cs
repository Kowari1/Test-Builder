using System.Text.Json.Serialization;

namespace Test_Builder.Models
{
    [JsonDerivedType(typeof(CheckBoxItem), nameof(CheckBoxItem))]
    [JsonDerivedType(typeof(RadioButtonItem), nameof(RadioButtonItem))]
    [JsonDerivedType(typeof(TextItem), nameof(TextItem))]
    public interface IItem
    {
        bool Compare(object obj);
    }
}

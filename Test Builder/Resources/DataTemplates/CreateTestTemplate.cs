using Test_Builder.Models;

namespace Test_Builder.Resources.DataTemplates
{
    public class CreateTestTemplate : DataTemplateSelector
    {
        public DataTemplate CheckBox { get; set; }
        public DataTemplate RadioButton { get; set; }
        public DataTemplate Text { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is CheckBoxItem) return CheckBox;
            else if (item is RadioButtonItem) return RadioButton;
            else return Text;
        }
    }
}

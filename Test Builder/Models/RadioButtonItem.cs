
using CommunityToolkit.Mvvm.ComponentModel;

namespace Test_Builder.Models
{
    public partial class RadioButtonItem :ObservableObject, IItem
    {
        private string text;
        public string Text
        {
            get => text;
            set => text = value;
        }

        [ObservableProperty]
        private bool correctAnswer;

        public bool Compare(object obj)
        {
            if (obj is RadioButtonItem rb)
            {
                if (correctAnswer == rb.correctAnswer)
                    return false;
            }
            return true;
        }
    }
}

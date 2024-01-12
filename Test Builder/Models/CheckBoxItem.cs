
using System.Security.Cryptography.X509Certificates;

namespace Test_Builder.Models
{
    public class CheckBoxItem : IItem
    {
        private string text;
        public string Text
        {
            get => text;
            set => text = value;
        }

        private bool correctAnswer = false;
        public bool CorrectAnswer
        {
            get => correctAnswer;
            set => correctAnswer = value;
        }

        public (string, int) IItem;

        public bool Compare(object obj)
        {
            if (obj is CheckBoxItem cb)
            {
                if (correctAnswer == cb.correctAnswer)
                    return false;
            }
            return true;
        }
    }
}

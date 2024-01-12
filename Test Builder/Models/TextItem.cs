
namespace Test_Builder.Models
{
    public class TextItem : IItem
    {
        private string correctAnswer;
        public string CorrectAnswer
        {
            get => correctAnswer;
            set => correctAnswer = value;
        }

        public bool Compare(object obj)
        {
            if (obj is TextItem ti)
            {
                if (correctAnswer == ti.correctAnswer)
                    return false;
            }
            return true;
        }
    }
}

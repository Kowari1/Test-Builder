using System.Collections.ObjectModel;

namespace Test_Builder.Models
{
    public partial class Question
    {
        public Question() 
        {
            items = new ObservableCollection<IItem>();
        }

        public ObservableCollection<IItem> items {get; set;}

        private string questionName;
        public string QuestionName
        {
            get => questionName;
            set => questionName = value;
        }     
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Test_Builder.Models
{
    public partial class Test : ObservableObject
    {
        public Test()
        {
            createTestDate = DateTime.Now;
        }

        public ObservableCollection<Question> Questions { get; set; }
        = new ObservableCollection<Question>();

        [ObservableProperty]
        private TimeSpan timerValue;
        
        private DateTime createTestDate;
        public DateTime CreateTestDate
        {
            get => createTestDate;
            private set => createTestDate = value;
        }

        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        private string pathFile;
        public string PathFile
        {
            get => pathFile;
            set => pathFile = value;
        }
    }
}

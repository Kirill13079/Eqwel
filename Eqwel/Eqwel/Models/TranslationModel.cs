using MvvmHelpers;

namespace Eqwel.Models
{
    public class TranslationModel : ObservableObject
    {
        private string _heading;
        public string Heading 
        {
            get => _heading;
            set 
            {
                _heading = value;
                OnPropertyChanged();
            }
        }

        private string _translition;
        public string Transltion
        {
            get => _translition;
            set 
            {
                _translition = value;
                OnPropertyChanged();
            }
        }

        private string _transcription;
        public string Transcription
        {
            get => _transcription;
            set
            {
                _transcription = value;
                OnPropertyChanged();
            }
        }
    }
}

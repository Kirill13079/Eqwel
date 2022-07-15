using Eqwel.Enums;
using Eqwel.Models;
using MvvmHelpers;

namespace Eqwel.ViewModels.Data
{
    public class DictoinaryViewModel : ObservableObject
    {
        private Language _sourceLanguage;
        public Language SourceLanguage
        {
            get => _sourceLanguage;
            set
            {
                _sourceLanguage = value;
                OnPropertyChanged();
            }
        }

        private Language _targetLanguage;
        public Language TargetLanguage
        {
            get => _targetLanguage;
            set
            {
                _targetLanguage = value;
                OnPropertyChanged();
            }
        }

        private TranslationModel _translation;
        public TranslationModel Translation
        {
            get => _translation;
            set
            {
                _translation = value;
                OnPropertyChanged();
            }
        }

        private bool _isUse = true;
        public bool IsUse
        {
            get => _isUse;
            set
            {
                _isUse = value;
                OnPropertyChanged();
            }
        }
    }
}

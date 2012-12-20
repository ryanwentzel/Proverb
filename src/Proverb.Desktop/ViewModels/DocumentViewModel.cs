using Caliburn.Micro;

namespace Proverb.ViewModels
{
    public sealed class DocumentViewModel : Screen
    {
        private const int DefaultFontSize = 16;

        private int _fontSize;
        public int FontSize
        {
            get
            {
                return _fontSize;
            }
            set
            {
                _fontSize = value;
                NotifyOfPropertyChange(() => FontSize);
            }
        }

        public DocumentViewModel()
        {
            FontSize = DefaultFontSize;
        }
    }
}

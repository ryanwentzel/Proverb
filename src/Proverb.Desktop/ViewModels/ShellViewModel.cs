
using Caliburn.Micro;
using Proverb.Helpers;
namespace Proverb.ViewModels
{
    public class ShellViewModel : PropertyChangedBase, IHaveDisplayName
    {
        private readonly IApplicationInfo _appInfo;

        public string DisplayName { get; set; }

        private DocumentViewModel _document;
        public DocumentViewModel Document
        {
            get
            {
                return _document;
            }
            private set
            {
                _document = value;
                NotifyOfPropertyChange(() => Document);
            }
        }

        public ShellViewModel(IApplicationInfo appInfo)
        {
            Ensure.ArgumentNotNull(appInfo, "appInfo");

            _appInfo = appInfo;

            DisplayName = _appInfo.Name;
            Document = new DocumentViewModel();
        }
    }
}

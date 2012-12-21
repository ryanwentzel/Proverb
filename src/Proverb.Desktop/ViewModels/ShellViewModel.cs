
using Caliburn.Micro;
using Proverb.Infrastructure;
namespace Proverb.ViewModels
{
    public class ShellViewModel : PropertyChangedBase, IHaveDisplayName
    {
        private readonly IApplicationInfo _appInfo;

        public string DisplayName { get; set; }

        private DocumentEditorViewModel _editor;
        public DocumentEditorViewModel Editor
        {
            get
            {
                return _editor;
            }
            set
            {
                _editor = value;
                NotifyOfPropertyChange(() => Editor);
            }
        }

        public ShellViewModel(IApplicationInfo appInfo)
        {
            Ensure.ArgumentNotNull(appInfo, "appInfo");

            _appInfo = appInfo;

            DisplayName = _appInfo.Name;
            Editor = new DocumentEditorViewModel();
        }
    }
}

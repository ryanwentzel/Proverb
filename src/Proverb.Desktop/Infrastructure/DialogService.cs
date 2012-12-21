using Microsoft.Win32;

namespace Proverb.Infrastructure
{
    public class DialogService : IDialogService
    {
        public string GetFileOpenPath(string title, string filter)
        {
            var dialog = new OpenFileDialog
            {
                Title = title,
                Filter = filter,
                Multiselect = false,
                CheckFileExists = true
            };

            string fileName = dialog.ShowDialog().Value ? dialog.FileName : "";

            return fileName;
        }

        public string GetFileSavePath(string title, string defaultExtension, string filter)
        {
            var dialog = new SaveFileDialog
            {
                Title = title,
                DefaultExt = defaultExtension,
                CheckFileExists = false,
                Filter = filter
            };

            string fileName = dialog.ShowDialog().Value ? dialog.FileName : "";

            return fileName;
        }
    }
}

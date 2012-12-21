using System;
using System.IO.Abstractions;
using Microsoft.Win32;

namespace Proverb.Infrastructure
{
    public class DialogService : IDialogService
    {
        private readonly IFileSystem _fileSystem;

        public DialogService(IFileSystem fileSystem)
        {
            Ensure.ArgumentNotNull(fileSystem, "fileSystem");

            _fileSystem = fileSystem;
        }

        public string GetFileOpenPath(string title, string filter)
        {
            throw new NotImplementedException();
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

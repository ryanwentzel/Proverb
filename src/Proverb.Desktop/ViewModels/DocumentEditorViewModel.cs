using System.Collections.Generic;
using System.IO;
using Caliburn.Micro;
using Caliburn.Micro.Contrib.Results;

namespace Proverb.ViewModels
{
    public class DocumentEditorViewModel : Screen
    {
        private const int DefaultFontSize = 16;

        private const int MinimumFontSize = 10;

        private const int MaximumFontSize = 32;

        private bool _isNewDocument;

        public int MinFontSize
        {
            get { return MinimumFontSize; }
        }

        public int MaxFontSize
        {
            get { return MaximumFontSize; }
        }

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

        private DocumentViewModel _document;
        public DocumentViewModel Document
        {
            get
            {
                return _document;
            }
            set
            {
                _document = value;
                NotifyOfPropertyChange(() => Document);
            }
        }

        public DocumentEditorViewModel()
        {
            FontSize = DefaultFontSize;
            Document = new DocumentViewModel();
            _isNewDocument = true;
        }

        public IEnumerable<IResult> Save()
        {
            yield return new SaveFileResult()
                .PromptForOverwrite()
                .FilterFiles(x => x.AddFilter("txt").WithDescription("Text files")
                                   .AddFilter("md").WithDescription("Markdown files"))
                .WithFileDo(file => { File.WriteAllText(file, Document.Document.Text); });
        }
    }
}

using Caliburn.Micro;
using ICSharpCode.AvalonEdit.Document;
using Proverb.Models;

namespace Proverb.ViewModels
{
    public class DocumentEditorViewModel : Screen
    {
        private const int DefaultFontSize = 16;

        private const int MinimumFontSize = 10;

        private const int MaximumFontSize = 32;

        private readonly IDocumentEditor _documentEditor;

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

        public ITextSource Document { get; private set; }

        public DocumentEditorViewModel(IDocumentEditor documentEditor)
        {
            Ensure.ArgumentNotNull(documentEditor, "documentEditor");

            _documentEditor = documentEditor;
            FontSize = DefaultFontSize;
            _documentEditor.New();
            Document = new TextDocument();
        }

        public async void Save()
        {
            _documentEditor.Document.Content = Document.CreateSnapshot().Text;
            var document = await _documentEditor.Save();
        }
    }
}

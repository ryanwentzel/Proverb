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

        private ITextSource _document;
        public ITextSource Document
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

        public DocumentEditorViewModel(IDocumentEditor documentEditor)
        {
            Ensure.ArgumentNotNull(documentEditor, "documentEditor");

            _documentEditor = documentEditor;
            _fontSize = DefaultFontSize;
            _documentEditor.New();
            _document = new TextDocument();
        }

        public async void Save()
        {
            _documentEditor.Document.Content = Document.CreateSnapshot().Text;
            var document = await _documentEditor.Save();
        }

        public async void New()
        {
            await _documentEditor.New();
            Document = new TextDocument();
        }

        public async void Open()
        {
            await _documentEditor.Open();
            Document = new TextDocument(_documentEditor.Document.Content.ToCharArray());
        }
    }
}

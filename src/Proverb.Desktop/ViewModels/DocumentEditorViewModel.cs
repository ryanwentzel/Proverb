using Caliburn.Micro;
using ICSharpCode.AvalonEdit.Document;
using Proverb.Infrastructure;
using Proverb.Models;

namespace Proverb.ViewModels
{
    public class DocumentEditorViewModel : Screen
    {
        private const int DefaultFontSize = 16;

        private const int MinimumFontSize = 10;

        private const int MaximumFontSize = 32;

        private readonly IDocumentEditor _documentEditor;

        private readonly IExporter _exporter;

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

        public DocumentEditorViewModel(IDocumentEditor documentEditor, IExporter exporter)
        {
            Ensure.ArgumentNotNull(documentEditor, "documentEditor");
            Ensure.ArgumentNotNull(exporter, "exporter");

            _documentEditor = documentEditor;
            _fontSize = DefaultFontSize;
            _documentEditor.New();
            _document = new TextDocument();
            _exporter = exporter;
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

        public async void Export()
        {
            _documentEditor.Document.Content = Document.CreateSnapshot().Text;
            string path = await _documentEditor.Export(_exporter);
        }

        public async void Preview()
        {
            _documentEditor.Document.Content = Document.CreateSnapshot().Text;
            await _documentEditor.Preview(_exporter);
        }
    }
}

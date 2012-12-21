using System;
using Caliburn.Micro;
using ICSharpCode.AvalonEdit.Document;

namespace Proverb.ViewModels
{
    public class DocumentEditorViewModel : Screen
    {
        private const int DefaultFontSize = 16;

        private const int MinimumFontSize = 10;

        private const int MaximumFontSize = 32;

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

        private TextDocument _document;
        public TextDocument Document
        {
            get
            {
                return _document;
            }
            set
            {
                if (_document != null)
                {
                    _document.TextChanged -= OnDocumentTextChanged;
                }
                _document = value;
                _document.TextChanged += OnDocumentTextChanged;
                NotifyOfPropertyChange(() => Document);
            }
        }

        public int WordCount
        {
            get
            {
                if (Document == null) return 0;
                if (Document.TextLength == 0) return 0;
                return Document.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }

        public DocumentEditorViewModel()
        {
            FontSize = DefaultFontSize;
            Document = new TextDocument();;
        }

        private void OnDocumentTextChanged(object sender, EventArgs e)
        {
            NotifyOfPropertyChange(() => WordCount);
#if DEBUG
            System.Diagnostics.Debug.WriteLine(Document.Text);
#endif
        }
    }
}

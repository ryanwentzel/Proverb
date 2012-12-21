using System;
using Caliburn.Micro;
using ICSharpCode.AvalonEdit.Document;

namespace Proverb.ViewModels
{
    public class DocumentViewModel : PropertyChangedBase
    {
        public ITextSource Document { get; private set; }

        public int WordCount
        {
            get
            {
                if (Document == null || Document.TextLength == 0) return 0;

                return Document.Text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }

        public int CharacterCount
        {
            get
            {
                if (Document == null) return 0;

                return Document.TextLength;
            }
        }

        public DocumentViewModel()
            : this(new TextDocument())
        {
        }

        public DocumentViewModel(ITextSource document)
        {
            Ensure.ArgumentNotNull(document, "document");

            Document = document;
            Document.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            NotifyOfPropertyChange(() => WordCount);
            NotifyOfPropertyChange(() => CharacterCount);
        }
    }
}

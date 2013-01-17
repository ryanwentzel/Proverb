
namespace Proverb.Document
{
    public class NewDocument : IDocument
    {
        public string Content { get; set; }

        public string Title { get; private set; }

        public string Path { get; private set; }

        public NewDocument()
        {
            Title = "new document";
            Content = "";
        }
    }
}

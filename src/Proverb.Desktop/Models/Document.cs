
namespace Proverb.Models
{
    public class Document : IDocument
    {
        public string Content { get; set; }

        public string Title { get; private set; }

        public string Path { get; private set; }

        public Document(string path, string content)
        {
            Ensure.ArgumentNotNull(path, "path");

            Path = path;
            Title = System.IO.Path.GetFileNameWithoutExtension(path);
            Content = content;
        }
    }
}

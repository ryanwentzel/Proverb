
namespace Proverb.Document
{
    public interface IDocument
    {
        string Content { get; set; }

        string Title { get; }

        string Path { get; }
    }
}

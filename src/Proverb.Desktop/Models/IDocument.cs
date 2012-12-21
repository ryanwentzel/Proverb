
namespace Proverb.Models
{
    public interface IDocument
    {
        string Content { get; set; }

        string Title { get; }

        string Path { get; }
    }
}

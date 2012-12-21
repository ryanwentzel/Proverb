
namespace Proverb.Infrastructure
{
    public interface IDialogService
    {
        string GetFileOpenPath(string title, string filter);

        string GetFileSavePath(string title, string defaultExtension, string filter);
    }
}

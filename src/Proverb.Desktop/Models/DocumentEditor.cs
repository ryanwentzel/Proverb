using System;
using System.Threading.Tasks;

namespace Proverb.Models
{
    public class DocumentEditor : IDocumentEditor
    {
        public IDocument Document
        {
            get { throw new NotImplementedException(); }
        }

        public Task<IDocument> Save()
        {
            throw new NotImplementedException();
        }

        public Task<IDocument> SaveAs()
        {
            throw new NotImplementedException();
        }

        public Task<IDocument> Open(string path)
        {
            throw new NotImplementedException();
        }
    }
}

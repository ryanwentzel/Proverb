﻿using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Proverb.Document;
using Proverb.Extensions;
using Proverb.Infrastructure;

namespace Proverb.Models
{
    public class DocumentEditor : IDocumentEditor
    {
        private readonly string _tempDirPath;
        private readonly IFileSystem _fileSystem;
        private readonly IFileWriterFactory _writerFactory;
        private readonly IDocumentFactory _documentFactory;
        private readonly IDialogService _dialogService;

        public IDocument Document { get; private set; }

        public DocumentEditor(
            IDocumentFactory documentFactory, 
            IFileSystem fileSystem,
            IFileWriterFactory writerFactory,
            IDialogService dialogService)
        {
            Ensure.ArgumentNotNull(documentFactory, "documentFactory");
            Ensure.ArgumentNotNull(fileSystem, "fileSystem");
            Ensure.ArgumentNotNull(writerFactory, "writerFactory");
            Ensure.ArgumentNotNull(dialogService, "dialogService");

            _documentFactory = documentFactory;
            _fileSystem = fileSystem;
            _tempDirPath = _fileSystem.Path.Combine(_fileSystem.Path.GetTempPath(), "Proverb");
            _writerFactory = writerFactory;
            _dialogService = dialogService;
            Document = _documentFactory.NewDocument();
        }

        public async Task<IDocument> Save()
        {
            if (string.IsNullOrEmpty(Document.Path)) return await SaveAs();

            var fileInfo = _fileSystem.FileInfo.FromFileName(Document.Path);
            // TODO: check if file is read-only

            var writer = _writerFactory.Create(Document.Path);
            return await writer.WriteAsync(Document.Content).ContinueWith<IDocument>(t => 
            {
                writer.Dispose();
                t.PropagateExceptions();

                return Document;
            });
        }

        public async Task<IDocument> SaveAs()
        {
            var path = _dialogService.GetFileSavePath("Save As", FileExtensions.Defaults.First(), FileExtensions.Filter);

            if (string.IsNullOrEmpty(path)) return await Task.FromResult(Document);

            return await _documentFactory.NewDocument(path, Document.Content).ContinueWith(t => 
            {
                t.PropagateExceptions();
                Document = t.Result;

                return Document;
            });
        }

        public async Task<IDocument> New()
        {
            return await Task.FromResult(_documentFactory.NewDocument()).ContinueWith(t => 
            {
                t.PropagateExceptions();
                Document = t.Result;

                return Document;
            });
        }

        public async Task<IDocument> Open()
        {
            var path = _dialogService.GetFileOpenPath("Open", FileExtensions.Filter);

            if (string.IsNullOrEmpty(path)) return await Task.FromResult(Document);

            return await _documentFactory.OpenDocument(path).ContinueWith(t => 
            {
                t.PropagateExceptions();
                Document = t.Result;

                return Document;
            });
        }

        public async Task<string> Export(IExporter exporter)
        {
            Ensure.ArgumentNotNull(exporter, "exporter");

            var path = _dialogService.GetFileSavePath("Export", FileExtensions.Html.First(), FileExtensions.HtmlFilter);
            if (string.IsNullOrEmpty(path)) return await Task.FromResult("");

            return await exporter.Export(Document, path);
        }

        public async Task<string> Preview(IExporter exporter)
        {
            Ensure.ArgumentNotNull(exporter, "exporter");

            EnsureTempDirExists();
            string path = _fileSystem.Path.Combine(_tempDirPath, "Proverb_preview.html");
            return await exporter.Export(Document, path).ContinueWith(t => 
            {
                t.PropagateExceptions();
                ProcessEx.Start(t.Result);

                return t.Result;
            });
        }

        private void EnsureTempDirExists()
        {
            if (!_fileSystem.Directory.Exists(_tempDirPath))
            {
                _fileSystem.Directory.CreateDirectory(_tempDirPath);
            }
        }
    }
}

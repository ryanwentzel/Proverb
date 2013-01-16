using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using Moq;
using Proverb.Infrastructure;
using Xunit;

namespace Proverb.Models
{
    public class DocumentEditorTests
    {
        [Fact]
        public async void SaveNewDocumentPromptsForPath()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var editor = new DocumentEditor(
                new Mock<IDocumentFactory>().Object, 
                new Mock<IFileSystem>().Object, 
                new Mock<IFileWriterFactory>().Object, 
                dialogService.Object);

            // Act
            await editor.New();
            await editor.Save();

            // Assert
            dialogService.Verify(svc => svc.GetFileSavePath(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        [Fact]
        public async void SaveAsPromptsForPath()
        {
            // Arrange
            var dialogService = new Mock<IDialogService>();
            var editor = new DocumentEditor(
                new Mock<IDocumentFactory>().Object,
                new Mock<IFileSystem>().Object,
                new Mock<IFileWriterFactory>().Object,
                dialogService.Object);

            // Act
            await editor.New();
            await editor.SaveAs();

            // Assert
            dialogService.Verify(svc => svc.GetFileSavePath(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
        }

        [Fact]
        public async void SaveAsReturnsDocumentWithExpectedPath()
        {
            // Arrange
            const string path = @"C:\docs\my_doc.md";
            var dialogService = new Mock<IDialogService>();
            dialogService.Setup(svc => svc.GetFileSavePath(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(path);
            var editor = new DocumentEditor(
                new Mock<IDocumentFactory>().Object,
                new MockFileSystem(new Dictionary<string, MockFileData>()),
                new Mock<IFileWriterFactory>().Object,
                dialogService.Object);

            // Act
            await editor.New();
            var document = await editor.SaveAs();

            // Assert
            Assert.Equal(path, document.Path);
        }

        [Fact]
        public async void NewCreatesInMemoryDocument()
        {
            // Arrange
            var editor = new DocumentEditor(
                new Mock<IDocumentFactory>().Object,
                new Mock<IFileSystem>().Object,
                new Mock<IFileWriterFactory>().Object,
                new Mock<IDialogService>().Object);

            // Act
            var document = await editor.New();

            // Assert
            Assert.True(string.IsNullOrEmpty(document.Path));
        }
    }
}

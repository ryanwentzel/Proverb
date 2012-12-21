using ICSharpCode.AvalonEdit.Document;
using Xunit;

namespace Proverb.ViewModels
{
    public sealed class DocumentViewModelTests
    {
        [Fact]
        public void WordCountUpdatesWhenTextChanged()
        {
            // Arrange
            var document = new TextDocument();
            var viewModel = new DocumentViewModel(document);
            var initialCount = viewModel.WordCount;

            // Act
            document.Text = "This is sample text.";
            var count1 = viewModel.WordCount;
            document.Text = "Hello";
            var count2 = viewModel.WordCount;

            // Assert
            Assert.True(count1 > initialCount);
            Assert.True(count2 < count1);
        }

        [Fact]
        public void CharacterCountUpdatesWhenTextChanged()
        {
            // Arrange
            var document = new TextDocument();
            var viewModel = new DocumentViewModel(document);
            var initialCount = viewModel.CharacterCount;

            // Act
            document.Text = "This is sample text.";
            var count1 = viewModel.CharacterCount;
            document.Text = "Hello";
            var count2 = viewModel.CharacterCount;

            // Assert
            Assert.True(count1 > initialCount);
            Assert.True(count2 < count1);
        }
    }
}

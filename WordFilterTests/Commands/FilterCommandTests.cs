using FakeItEasy;
using System.IO.Abstractions;
using TextFilter.Commands;
using TextFilter.Containers;

namespace TextFilterTests.Commands;

public class FilterCommandTests
{
    [Fact]
    public void GetFilteredText_TextFiltered_Returns_AccurateText()
    {
        var fileSystem = A.Fake<IFileSystem>();
        var fileContainer = A.Fake<FileContainer>(options => options.WithArgumentsForConstructor(
             new object[] { "", fileSystem }
            ));
        string textReturned = "averylongwordConversation";
        A.CallTo(() => fileContainer.TextContent).Returns(new List<string>() { "hello there averylongword", "dummy Conversation" });
        A.CallTo(() => fileContainer.TextFilter.ApplyFilter(A<string>.Ignored)).Returns(textReturned);

        var command = new FilterCommand();
        string result = command.GetFilteredText(fileContainer);

        A.CallTo(() => fileContainer.TextFilter).MustHaveHappened();
        A.CallTo(() => fileContainer.TextFilter.ApplyFilter(A<string>.Ignored)).MustHaveHappened();
        A.CallTo(() => fileContainer.TextFilter.ApplyFilter(A<string>.Ignored)).MustHaveHappened();

        result.ShouldBe(textReturned + Environment.NewLine + textReturned + Environment.NewLine);
    }
}

using FakeItEasy;
using System.IO.Abstractions;
using TextFilter.Services;

namespace TextFilterTests.Services
{
    public class FileContainerValidationServiceTests
    {
        [Fact]
        public void IsFilePathValid_InvalidFileSpecified_Returns_Error()
        {
            var fileSystem = A.Fake<IFileSystem>();
            A.CallTo(() => fileSystem.File.Exists(A<string>.Ignored)).Returns(false);
            var validationService = new FileContainerValidationService(fileSystem);
            var result = validationService.IsFilePathValid("Invalid Path");
            result.Success.ShouldBeFalse();
            result.ErrorMessage.ShouldBe("File must exist");
        }

        [Fact]
        public void IsFilePathValid_NullFilePath_ReturnsError()
        {
            var fileSystem = A.Fake<IFileSystem>();
            var validationService = new FileContainerValidationService(fileSystem);
            var result = validationService.IsFilePathValid(null);
            result.Success.ShouldBeFalse();
            result.ErrorMessage.ShouldBe("Path must be specified");
        }
        [Fact]
        public void IsFilePathValid_ValidFileSpecified_Returns_Success()
        {
            var fileSystem = A.Fake<IFileSystem>();
            A.CallTo(() => fileSystem.File.Exists(A<string>.Ignored)).Returns(true);
            var validationService = new FileContainerValidationService(fileSystem);
            var result = validationService.IsFilePathValid("Valid Path");
            result.Success.ShouldBeTrue();
            result.ErrorMessage.ShouldBe(string.Empty);
        }
    }
}

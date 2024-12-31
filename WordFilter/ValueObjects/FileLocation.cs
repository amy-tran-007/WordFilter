using TextFilter.Services;

namespace TextFilter.ValueObjects
{
    internal class FileLocation
    {
        public string Value { get; }
        public static implicit operator string(FileLocation location) { return location.Value; }

        private FileLocation(string value)
        {
            Value = value;
        }

        public static Result TryParse(IFileLocationValidator validator, string? value, out FileLocation? result)
        {
            var isValidResult = validator.IsFilePathValid(value);
            if (isValidResult.Failed)
            {
                result = null;
                return isValidResult;
            }
            result = new FileLocation(value!);
            return Result.OK();
        }

    }
}

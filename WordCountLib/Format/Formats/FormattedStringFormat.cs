using WordCountLib.TextAnalysisString;

namespace WordCountLib.Format.Formats
{
    public class FormattedStringFormat : IFormat<IFormattedString>
    {
        public string Format(IFormattedString input)
        {
            return input.ToFormattedString();
        }
    }
}

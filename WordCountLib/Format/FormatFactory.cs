using WordCountLib.Format.Formats;
using WordCountLib.TextAnalysisString;

namespace WordCountLib.Format
{
    public class FormatFactory
    {
        private FormatFactory() { }

        public static string Format(IFormattedString formattedStringObject, string formatName)
        {
            switch (formatName)
            {
                case "json":
                    return new JsonFormat().Format(formattedStringObject);
                case "text":
                    return new FormattedStringFormat().Format(formattedStringObject);
                default:
                    return new JsonFormat().Format(formattedStringObject);
            }
        }
    }
}

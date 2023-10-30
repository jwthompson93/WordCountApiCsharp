using System.Text.Json;
using WordCountLib.TextAnalysisString;

namespace WordCountLib.Format.Formats
{
    public class JsonFormat : IFormat<object>
    {

        public string Format(object input)
        {
            return JsonSerializer.Serialize<object>(input);
        }
    }
}

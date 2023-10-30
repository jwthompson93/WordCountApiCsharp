using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCountLib.File
{
    public class TextFileReader
    {
        public string getTextFromFile(Stream stream)
        {
            StringBuilder txt = new StringBuilder();

            try
            {
                string line;
                StreamReader streamReader = new StreamReader(stream);
                while ((line = streamReader.ReadLine()) != null)
                {
                    txt.AppendLine(line);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return txt.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCountLib.Process
{
    public interface IProcess<T>
    {
        public string Process(T input, string outputFormat);
    }
}

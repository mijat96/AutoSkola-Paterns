using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.model
{
    public class Logger : ILogger
    {
        public Logger() { }
        ~Logger()
        {

        }

        public void LogKlijent(string text, DateTime time)
        {
            string path = @"..\LoggerKlijent.txt";
            StringBuilder sb = new StringBuilder();

            sb.Append("\n");
            sb.Append(text + " " + time.ToString());

            if (!File.Exists(path))
                File.WriteAllText(path, sb.ToString());
            else
                File.AppendAllText(path, sb.ToString());
        }

        public void LogServer(string text, DateTime time)
        {
            string path = @"..\LoggerServer.txt";
            StringBuilder sb = new StringBuilder();

            sb.Append("\n");
            sb.Append(text + " " + time.ToString());

            if (!File.Exists(path))
                File.WriteAllText(path, sb.ToString());
            else
                File.AppendAllText(path, sb.ToString());
        }
    }
}

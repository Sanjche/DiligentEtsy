using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiligentEtsy.Lib
{
    class Logger
    {
        public static string logFilename = @"C:\DiligentEtsy\Etsy.log";

        public static void SetFileName(string fileName)
        {
            logFilename = fileName;
        }

        public static void Empty()
        {
            File.WriteAllText(logFilename, string.Empty);
        }



        public static void WriteLog(string logMessage)
        {
            using (StreamWriter fileHandle = new StreamWriter(logFilename, true))
            {
                fileHandle.WriteLine(logMessage);
            }
        }


        public static void Log(string messageType, string logMessage)
        {
            WriteLog($"[{ DateTime.Now}],{ messageType}:,{logMessage}");

        }

        public static string Separator(char character = '=')
        {
            return new string(character, 100);
        }

        public static void BeginTest(string testName)
        {
            WriteLog(Separator());
            WriteLog($"Starting test:{testName}");

        }

        public static void EndTest()
        {
            WriteLog(Separator());
        }
    }
}

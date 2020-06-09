using System;
using System.Collections.Generic;
using System.Text;

namespace export_xyz
{
    class Logger
    {
        const string DEF_LOG_FILE_PATH = "log.txt";

        public static void CreateLogEntry(string message)
        {
            using (System.IO.StreamWriter logFile =
                new System.IO.StreamWriter(DEF_LOG_FILE_PATH, true))
            {
                String timeStamp = DateTime.Now.ToString();
                logFile.WriteLine(timeStamp + " : " + message);
            }
        }
    }
}

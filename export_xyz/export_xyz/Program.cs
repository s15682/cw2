using System;
using System.IO;

namespace export_xyz
{
    class Program
    {
        const string DEF_LOG_FILE_PATH = "log.txt";
        const string DEF_IN_FILE_PATH = "dane.csv";
        const string DEF_OUT_FILE_PATH = "result.xml";

        static void Main(string[] args)
        {
            FileStream inputFile = SetInputFile(args[0]);

            // FileStream outpuFile = SetOutputFile(args[1]); 
        }


        private static FileStream SetInputFile(string inputFileAddress)
        {
            FileStream inputFile;
            try
            {
                inputFile = new FileStream(inputFileAddress, FileMode.Open);
            }
            catch (ArgumentException argEx)
            {
                CreateLogEntry("Podana scieżka pliku z danymi jest niepoprawna");
                inputFile = new FileStream(DEF_IN_FILE_PATH, FileMode.Open);
            }
            catch (FileNotFoundException fnfEx)
            {
                string msg = "Plik " + inputFileAddress + " nie istnieje"; 
                CreateLogEntry(msg);
                inputFile = new FileStream(DEF_IN_FILE_PATH, FileMode.Open);
            }
            return inputFile;     
        }

        private static void CreateLogEntry(string message)
        {
            using (System.IO.StreamWriter logFile =
                new System.IO.StreamWriter(DEF_LOG_FILE_PATH, true))
            {
                String timeStamp = DateTime.Now.ToString();
                logFile.WriteLine(timeStamp+" : "+message);
            }
        }

        private static FileStream SetOutputFile(string outputFileAddress)
        {
            throw new NotImplementedException();
        }

        
    }

        
}

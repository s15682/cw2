using System;
using System.Collections.Generic;
using System.IO;

namespace export_xyz
{
    class Program
    {
        
        const string DEF_IN_FILE_PATH = "dane.csv";
        const string DEF_OUT_FILE_PATH = "result.xml";

        static void Main(string[] args)
        {
            FileStream inputFile = SetInputFile(args[0]);
            StudentsCreator creator = new StudentsCreator();
            List<Student> studentList = creator.CreateStudentsList(inputFile); 
            foreach( Student st in studentList)
            {
                Console.WriteLine(st); 
            }

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
                Logger.CreateLogEntry("Podana scieżka pliku z danymi jest niepoprawna");
                inputFile = new FileStream(DEF_IN_FILE_PATH, FileMode.Open);
            }
            catch (FileNotFoundException fnfEx)
            {
                string msg = "Plik " + inputFileAddress + " nie istnieje";
                Logger.CreateLogEntry(msg);
                inputFile = new FileStream(DEF_IN_FILE_PATH, FileMode.Open);
            }
            return inputFile;     
        }

        private static FileStream SetOutputFile(string outputFileAddress)
        {
            throw new NotImplementedException();
        }

        
    }

        
}

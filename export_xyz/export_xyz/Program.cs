using System;
using System.Collections.Generic;
using System.IO;

namespace export_xyz
{
    class Program
    {
        enum ReturnTypes { XML }

        const string DEF_IN_FILE_PATH = "dane.csv";
        const string DEF_OUT_FILE_PATH = "result.xml";

        static string outputFilePath;
        static string inputFilePath;
        static ReturnTypes returnType; 


        static void Main(string[] args)
        {
            SetParameters(args); 
            FileStream inputFile = SetInputFile(inputFilePath);
            StudentsCreator creator = new StudentsCreator();
            List<Student> studentList = creator.CreateStudentsList(inputFile);
            CreateAndFillOutputFile(studentList, returnType);  
            inputFile.Close(); 
        }

        private static void SetParameters(string[] args)
        {
            if (args.Length < 3)
            {
                outputFilePath = DEF_OUT_FILE_PATH;
                inputFilePath = DEF_IN_FILE_PATH;
                returnType = ReturnTypes.XML;
            }
            else
            {
                outputFilePath = args[1];
                inputFilePath = args[0];
                returnType = SetReturnType(args[2]);
            }
        }

        private static ReturnTypes SetReturnType(string typeName)
        {
            if (typeName.ToLower() == "xml") { return ReturnTypes.XML; }
            Logger.CreateLogEntry("podano nieprawidłowy typ lub podany typ nie jest obsługiwany"); 
            return ReturnTypes.XML;
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

        private static void CreateAndFillOutputFile(List<Student> studentList, ReturnTypes returnType)
        {
            IOutputFileCreator fileCreator = null;   
            switch (returnType)
            {
                case ReturnTypes.XML:
                    fileCreator = new XmlOutputFileCreator(outputFilePath);
                    break;
                default:
                    Logger.CreateLogEntry("Brak implementacji dla typu " + returnType);
                    break;
            }
            if( fileCreator!=null) fileCreator.CreateOutputFile(studentList);

        }


    }
        
}

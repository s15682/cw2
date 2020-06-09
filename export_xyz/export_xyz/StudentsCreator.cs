using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace export_xyz
{
    public class StudentsCreator
    {
        List<Student> students = new List<Student>();
        HashSet<string> indexNumbers = new HashSet<string>(); 

        public List<Student> CreateStudentsList(FileStream inputFile)
        {
            students.Clear();
            indexNumbers.Clear(); 

            using(var inputStream = new StreamReader(inputFile))
            {
                string record; 
                while ((record = inputStream.ReadLine()) != null)
                {
                    Student nextStudent; 
                    try
                    {
                        nextStudent = new Student(record); 
                        if (!indexNumbers.Contains(nextStudent.IndexNumber))
                        {
                            indexNumbers.Add(nextStudent.IndexNumber);
                            students.Add(nextStudent); 
                        } else
                        {
                            Logger.CreateLogEntry("Zduplikowany numer indeksu: "
                                + nextStudent.IndexNumber + " " + nextStudent.Imie + " " + nextStudent.Nazwisko); 
                        }
                    } catch (Exception ex)
                    {
                        Logger.CreateLogEntry(ex.Message); 
                    }
                }
            }
            return students; 
        }




    }
}

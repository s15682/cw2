using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace export_xyz
{
    
    [XmlType(TypeName ="student")]
    public class Student
    {
        [XmlAttribute(AttributeName = "indexNumber")] public string IndexNumber { get; set; }
        [XmlElement(ElementName = "fname")] public string Imie { get; set; }
        [XmlElement(ElementName = "lname")] public string Nazwisko { get; set; }
        [XmlElement(ElementName = "birthdate")] public string DataUrodzenia { get; set; }
        [XmlElement(ElementName = "email")] public string Email { get; set; }
        [XmlElement(ElementName = "mothersName")] public string ImieMatki { get; set; }
        [XmlElement(ElementName = "fathersName")] public string ImieOjca { get; set; }
        [XmlElement(ElementName = "studies")] public Studies Studia { get; set; }

        public Student() { }

        public Student(string studentData)
        {
            string[] studentDataArray = studentData.Split(',');
            SetNameAndLastname(studentDataArray);
            CheckForCorrentData(studentDataArray);
            SetStudies(studentDataArray);
            SetIndexNumber(studentDataArray[4]);
            SetBirthDate(studentDataArray[5]);
            SetEmail(studentDataArray[6]);
            SetParentsName(studentDataArray[7], studentDataArray[8]); 

        }

        public override string ToString()
        {
            return Imie + "," + Nazwisko +","+ IndexNumber+"," + Studia + "," + DataUrodzenia + "," + Email + "," + ImieMatki + "," + ImieOjca;
        }
        private void SetNameAndLastname(string[] studentDataArray)
        {
            Imie = studentDataArray[0];
            Nazwisko = studentDataArray[1];
        }

        private void CheckForCorrentData(string[] studentDataArray)
        {
            if (studentDataArray.Length < 9)
            {
                throw new StudentEntryMissingData("Zbyt mała ilość kolumn dla studenta " + Imie + " " + Nazwisko);
            }
            foreach (var data in studentDataArray)
            {
                if (data.Length == 0)
                {
                    throw new StudentEntryMissingData("We wpisie studenta  " + Imie + " " + Nazwisko + " występują puste wartości");
                }
            }
        }

        private void SetStudies(string[] studentDataArray)
        {
            try
            {
                Studia = new Studies(studentDataArray[2], studentDataArray[3]);
            }
            catch (InvalidStudiesMode ex)
            {
                throw new InvalidStudiesMode(ex.Message + " " + Imie + " " + Nazwisko);
            }
        }

        private void SetIndexNumber(string number)
        {
            IndexNumber = 's' + number; 
        }

        private void SetBirthDate(string date)
        {
            string[] dateArray = date.Split('-');
            DataUrodzenia = dateArray[2] + "." + dateArray[1] + "." + dateArray[0]; 
        }

        private void SetEmail(string email)
        {
            Email = email; 
        }

        private void SetParentsName(string mname, string fname)
        {
            ImieMatki = mname;
            ImieOjca = fname; 
        }

    }

    public class StudentEntryMissingData : Exception
    {
        public StudentEntryMissingData() { }
        public StudentEntryMissingData(string message) : base(message) { } 
    }

}

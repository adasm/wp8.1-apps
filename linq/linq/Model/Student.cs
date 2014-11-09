using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace linq.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public float MarkAverage { get; set; }


        private static List<Student> studentsList = null;

        public static List<Student> GetList()
        {
            if (studentsList == null)
            {
                studentsList = new List<Student>();

                var rnd = new Random();
                var names = new string[] {"Henryk", "Jacek", "Adam", "Lukasz","Marek","Jozef","Olaf"};
                var surnames = new string[] {"Sienkiewicz", "Jacekiewicz", "Adamowski", "Krolewski","Ostrozny"};
                for (var i = 0; i < 50; i++)
                {
                    studentsList.Add(new Student()
                    {
                        Id = i+1,
                        Index = rnd.Next(191000, 193999).ToString(CultureInfo.CurrentCulture),
                        Name = names[rnd.Next(names.Length)],
                        Surname = surnames[rnd.Next(surnames.Length)],
                        BirthDate = new DateTime(rnd.Next(1988,1994), rnd.Next(1,13), rnd.Next(1,29)),
                        MarkAverage = (float)(2.5 + rnd.NextDouble()*3.0)
                    });
                }

            }
            return studentsList;
        }

    }
}

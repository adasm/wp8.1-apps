using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq.Model
{
    class StudentCourse
    {
        public Student StudentInstance { get; set; }
        public Course CourseInstance { get; set; }
        public string StudentIndex
        {
            get { return StudentInstance.Index; }
        }
        public string CourseCode
        {
            get { return CourseInstance.Code; }
        }
        public float Mark { get; set; }
        public DateTime Date { get; set; }

        private static List<StudentCourse> studentCoursesList = null;

        public static List<StudentCourse> GetList()
        {
            if (studentCoursesList == null)
            {
                studentCoursesList = new List<StudentCourse>();

                var rnd = new Random();
                foreach(var stud in Student.GetList())
                {
                    foreach (var cour in Course.GetList())
                    {
                        studentCoursesList.Add(new StudentCourse()
                        {
                            StudentInstance = stud,
                            CourseInstance = cour,
                            Mark = (float) (2.5 + rnd.NextDouble()*3.0),
                            Date = new DateTime(rnd.Next(2013,2015), rnd.Next(1,13), rnd.Next(1,29)),

                        });
                    }
                    
                }
            }
            return studentCoursesList;
        }
    }
}

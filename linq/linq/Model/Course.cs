using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq.Model
{
    class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        private static List<Course> coursesList = null;

        public static List<Course> GetList()
        {
            if (coursesList == null)
            {
                coursesList = new List<Course>();

                var rnd = new Random();
                var names = new string[] { "Analiza matematyczna", "Matematyka", "Fizyka", "Java", "Sieci komputerowe", "Sztuczna inteligencja" };
                int id = 1;
                foreach(var name in names)
                {
                    coursesList.Add(new Course()
                    {
                        Id = id++,
                        Code = "z0" + rnd.Next(1, 3).ToString(CultureInfo.CurrentCulture) + "-0" + rnd.Next(0, 10).ToString(CultureInfo.CurrentCulture) + (char)rnd.Next('a', 'z'), 
                        Name = name,
                    });
                }

            }
            return coursesList;
        }
    }
}

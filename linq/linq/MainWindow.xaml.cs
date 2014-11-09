using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using linq.Model;

namespace linq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static bool UseOperators = false;
        public MainWindow()
        {
            InitializeComponent();

            Update();
        }

        private void Update()
        {
            MenuItemMethod.Header = UseOperators ? "LINQ: Use operators" : "LINQ: Use methods";

            UpdateData();
            UpdateStudentAge();
            UpdateStudentCourseFailed();
            AgeFilterTextBox.Text = "25";
            MarkFilterTextBox.Text = "3";
            UpdateStudentAgeFilter(25);
            UpdateStudentMarkFilter(3);
        }

        private void UpdateData()
        {
            DataStudents.ItemsSource = null;
            DataCourses.ItemsSource = null;
            DataStudentCourses.ItemsSource = null;

            DataStudents.ItemsSource = Student.GetList();
            DataCourses.ItemsSource = Course.GetList();
            DataStudentCourses.ItemsSource = StudentCourse.GetList();

            DataStudentsLabel.Content = "Total rows number: " + DataStudents.Items.Count;
            DataCoursesLabel.Content = "Total rows number: " + DataCourses.Items.Count;
            DataStudentCoursesLabel.Content = "Total rows number: " + DataStudentCourses.Items.Count;
            
        }

        private void UpdateStudentAge()
        {
            DataQueryStudentAge.ItemsSource = null;
            if (UseOperators)
            {
                var query =
                    from s in Student.GetList()
                    select new
                    {
                        s.Id,
                        s.Index,
                        s.Name,
                        s.Surname,
                        Age = (new DateTime(1, 1, 1) + (DateTime.Now - s.BirthDate)).Year - 1
                    };
                DataQueryStudentAge.ItemsSource = query;
            }
            else
            {
                DataQueryStudentAge.ItemsSource =
                    Student.GetList()
                        .Select(
                            s =>
                                new
                                {
                                    s.Id,
                                    s.Index,
                                    s.Name,
                                    s.Surname,
                                    Age = (new DateTime(1, 1, 1) + (DateTime.Now - s.BirthDate)).Year - 1
                                });
            }

            DataQueryStudentAgeLabel.Content = "Total rows number: " + DataQueryStudentAge.Items.Count;
        }

        private void UpdateStudentAgeFilter(int minAge)
        {
            DataQueryStudentAgeFilter.ItemsSource = null;
            if (UseOperators)
            {
                var query =
                    from ss in (from s in Student.GetList()
                    select new
                    {
                        s.Id,
                        s.Index,
                        s.Name,
                        s.Surname,
                        s.BirthDate,
                        s.MarkAverage,
                        Age = (new DateTime(1, 1, 1) + (DateTime.Now - s.BirthDate)).Year - 1
                    })
                    where ss.Age >= minAge
                    select ss;
                DataQueryStudentAgeFilter.ItemsSource = query;
            }
            else
            {
                DataQueryStudentAgeFilter.ItemsSource =
                    Student.GetList()
                        .Select(
                            s => 
                                new
                                {
                                    s.Id,
                                    s.Index,
                                    s.Name,
                                    s.Surname,
                                    s.BirthDate,
                                    s.MarkAverage,
                                    Age = (new DateTime(1, 1, 1) + (DateTime.Now - s.BirthDate)).Year - 1
                                })
                        .Where(s => s.Age >= minAge);
            }

            DataQueryStudentAgeFilterLabel.Content = "Total rows number: " + DataQueryStudentAgeFilter.Items.Count;
        }

        private void UpdateStudentCourseFailed()
        {
            DataQueryStudentCourseFailed.ItemsSource = null;
            if (UseOperators)
            {
                var query =
                    (from sc in StudentCourse.GetList()
                    where sc.Mark < 3
                    select new
                    {
                        StudentId = sc.StudentInstance.Id,
                        sc.StudentIndex,
                        sc.StudentInstance.Name,
                        sc.StudentInstance.Surname,
                        sc.StudentInstance.BirthDate,
                        sc.StudentInstance.MarkAverage
                    }).Distinct();
                DataQueryStudentCourseFailed.ItemsSource = query;
            }
            else
            {
                DataQueryStudentCourseFailed.ItemsSource =
                    StudentCourse.GetList()
                        .Where(sc => sc.Mark < 3)
                        .Select(
                            sc =>
                                new
                                {
                                    StudentId = sc.StudentInstance.Id,
                                    sc.StudentIndex,
                                    sc.StudentInstance.Name,
                                    sc.StudentInstance.Surname,
                                    sc.StudentInstance.BirthDate,
                                    sc.StudentInstance.MarkAverage
                                })
                        .Distinct();

            }

            DataQueryStudentCourseFailedLabel.Content = "Total rows number: " + DataQueryStudentCourseFailed.Items.Count;
        }

        private void UpdateStudentMarkFilter(float maxMark)
        {
            DataQueryStudentMarkFilter.ItemsSource = null;
            if (UseOperators)
            {
                var query =
                    (from sc in StudentCourse.GetList()
                        where sc.Mark < maxMark
                        select new
                        {
                            StudentId = sc.StudentInstance.Id,
                            sc.StudentIndex,
                            sc.StudentInstance.Name,
                            sc.StudentInstance.Surname,
                            sc.StudentInstance.BirthDate,
                            sc.StudentInstance.MarkAverage,
                            CourseName = sc.CourseInstance.Name,
                            sc.Mark
                        });
                DataQueryStudentMarkFilter.ItemsSource = query;
            }
            else
            {
                DataQueryStudentMarkFilter.ItemsSource =
                    StudentCourse.GetList()
                        .Where(sc => sc.Mark < maxMark)
                        .Select(
                            sc =>
                                new
                                {
                                    StudentId = sc.StudentInstance.Id,
                                    sc.StudentIndex,
                                    sc.StudentInstance.Name,
                                    sc.StudentInstance.Surname,
                                    sc.StudentInstance.BirthDate,
                                    sc.StudentInstance.MarkAverage,
                                    CourseName = sc.CourseInstance.Name,
                                    sc.Mark
                                });

            }

            DataQueryStudentMarkFilterLabel.Content = "Total rows number: " + DataQueryStudentMarkFilter.Items.Count;
        }

        private void FilterTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, e.Text.Length - 1) && !char.IsPunctuation(e.Text, e.Text.Length - 1);
        }

        private void AgeFilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            int minAge;
            if (!int.TryParse(AgeFilterTextBox.Text, out minAge))
                minAge = 0;
            UpdateStudentAgeFilter(minAge);
        }

        private void MarkFilterTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            float maxMark;
            if (!float.TryParse(MarkFilterTextBox.Text, out maxMark))
                maxMark = 6;
            UpdateStudentMarkFilter(maxMark);
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            UseOperators = !UseOperators;
            MenuItemMethod.Header = UseOperators ? "LINQ: Use operators" : "LINQ: Use methods";
            Update();
        }

        private void ButtonAgeFilterReset_OnClick(object sender, RoutedEventArgs e)
        {
            AgeFilterTextBox.Text = "";
            UpdateStudentAgeFilter(0);
        }

        private void ButtonMarkFilterReset_OnClick(object sender, RoutedEventArgs e)
        {
            MarkFilterTextBox.Text = "";
            UpdateStudentMarkFilter(6);
        }
    }
}

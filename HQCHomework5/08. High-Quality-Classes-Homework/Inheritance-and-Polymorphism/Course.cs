namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;

    public abstract class Course
    {
        protected Course(string courseName, string teacherName = null, IList<string> students = null, string location = null)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
            this.Location = location;
        }

        public string Name { get; set; }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        public string Location { get; set; }

        public string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}

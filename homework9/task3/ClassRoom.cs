using System.Collections.Generic;

namespace task3
{
    internal class ClassRoom
    {
        public List<Student> students { get; set; }

        public ClassRoom(List<Student> students) { 
            this.students = students;
        }

        public void studentsInAction()
        {
            foreach (var student in students)
            {
                student.Read();
                student.Write();
                student.Study();
                student.Relax();
            }
        }
    }
}

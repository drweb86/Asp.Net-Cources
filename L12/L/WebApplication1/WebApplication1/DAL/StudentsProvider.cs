using System.Collections.Generic;
using WebApplication1.Database;

namespace WebApplication1.DAL
{
    public class StudentsProvider
    {
        public List<string> GetStudents()
        {
            return Db.Students;
        }

        public void AddStudent(string student)
        {
            Db.Students.Add(student);
        }
    }
}
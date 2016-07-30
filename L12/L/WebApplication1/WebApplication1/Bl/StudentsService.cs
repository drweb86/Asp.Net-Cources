using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAL;

namespace WebApplication1.Bl
{
    public class StudentsService
    {
        private readonly StudentsProvider _provider = new StudentsProvider();

        public List<string> GetStudents()
        {
            return _provider.GetStudents();
        }

        public void AddStudent(string student)
        {
            _provider.AddStudent(student);
        }

        public int StudentsCount()
        {
            return _provider.GetStudents().Count;
        }
    }
}
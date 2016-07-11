using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace L5.Models
{
    internal class Song
    {
        public Song(int id, string name, int time)
        {
            Id = id;
            Name = name;
            Time = time;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
    }

    class LinqToXml
    {
        private const string XmlFileName = @"C:\Users\drweb86\Documents\Asp.Net-Cources\L5\L\L5\L5\Models\Album.xml";

        public List<Song> GetSongs()
        {
            var doc = XDocument.Load(XmlFileName);

            var query = from song in doc.Root.Elements("song")
                        select new Song(
                            int.Parse(song.Attribute("id").Value),
                            song.Value,
                            int.Parse(song.Attribute("time").Value));
                            
                            
            return query.ToList();
        }
    }



    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class DemoLinq
    {
        private readonly List<Student> _students = new List<Student>
            {
                new Student {Name = "Ivan", Surname = "Petrovich"},
            };

        public List<Student> GetStudents()
        {
            var query = (
                from Student student in _students
                where student.Name.Contains('a')
                select student);

            return query.ToList();

            //query.Count() executes query and calculates result amount each time its called. Ass-method.

            //trashh code
            for (int i = 0; i < query.Count(); i++)
            {
                if (i == 0) 
                    _students.Add(new Student() {Name = "Тетя Нюра", Surname = "8 высшее"});
            }

        }
    }
}
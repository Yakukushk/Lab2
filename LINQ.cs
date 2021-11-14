using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2
{
    class LINQ : IStrategy
    {
        List<Student> info = new List<Student>();
        XDocument doc = new XDocument();
        public LINQ(string path) {
            doc = XDocument.Load(path);
        }

        public List<Student> Algorithm(Student student, string path) {
            List<XElement> match = (from val in doc.Descendants("student")
                                    where
                                    ((student.Speciality == null || student.Speciality == val.Parent.Parent.Attribute("SPECIALITY").Value) &&
                                    (student.Group == null || student.Group == val.Parent.Attribute("GROUP").Value) &&
                                    (student.Room == null || student.Room == val.Attribute("ROOM").Value) &&
                                    (student.Surname == null || student.Surname == val.Attribute("SURNAME").Value) &&
                                    (student.Name == null || student.Name == val.Attribute("NAME").Value))
                                    select val).ToList();
            foreach (XElement obj in match) {
                Student student1 = new Student();
                student1.Speciality = obj.Parent.Parent.Attribute("SPECIALITY").Value;
                student1.Group = obj.Parent.Attribute("GROUP").Value;
                student1.Room = obj.Attribute("ROOM").Value;
                student1.Surname = obj.Attribute("SURNAME").Value;
                student1.Name = obj.Attribute("NAME").Value;
                info.Add(student1);
            }
            return info;
        }
    }
}

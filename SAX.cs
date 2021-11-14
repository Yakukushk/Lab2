using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2
{
    class SAX : IStrategy
    {
        XmlDocument documents = new XmlDocument();
        public SAX(string path) {
            documents.Load(path);
        }
        public List<Student> Algorithm(Student student, string path) {
            List<Student> info = new List<Student>();
            info.Clear();
            var Reader = new XmlTextReader("");
            List<Student> result = new List<Student>();
            Student student1 = null;
            string _speciality = null;
            string _group = null;
            while (Reader.Read()) {
                if (Reader.Name == "speaciality") {
                    while (Reader.MoveToNextAttribute()) {
                        if (Reader.Name == "SPECIALITY") {
                            _speciality = Reader.Value;
                        }
                    }
                }
                if (Reader.Name == "group") {
                    while (Reader.MoveToNextAttribute()) {
                        if (Reader.Name == "GROUP") {
                            _group = Reader.Value;
                        }
                    }
                }
                if (Reader.Name == "student") {
                    if (student1 == null)
                    {
                        student1 = new Student();
                        student1.Speciality = _speciality;
                        student1.Group = _group;
                    }
                    else {
                        student1 = new Student();
                        student1.Speciality = _speciality;
                        student1.Group = _group;
                    }
                    if (Reader.HasAttributes) {
                        while (Reader.MoveToNextAttribute()) {
                            if (Reader.Name == "ROOM") {
                                student1.Room = Reader.Value;
                            }
                            if (Reader.Name == "SURNAME") {
                                student1.Surname = Reader.Value;
                            }
                            if (Reader.Name == "NAME") {
                                student1.Name = Reader.Value;
                            }
                        }
                    }
                    if (student1.Surname != null) {
                        result.Add(student1);
                    }
                }
            }
            info = Filtr(result, student);
            return info;
        }
        public List<Student> Filtr(List<Student> allStud, Student param) {
            List<Student> result = new List<Student>();
            if (allStud != null) {
                foreach (Student e in allStud) {
                    try
                    {
                        if ((e.Speciality == param.Speciality || param.Speciality == null) &&
                                (e.Group == param.Group || param.Group == null) &&
                                (e.Room == param.Room || param.Room == null) &&
                                (e.Surname == param.Surname || param.Room == null) &&
                                (e.Name == param.Name || param.Name == null)
                                )
                        {
                            result.Add(e);
                        }
                    }
                    catch { }
                }
            }
            return result; 
        }
    }
}

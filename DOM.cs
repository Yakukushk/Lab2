using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2
{
    class DOM : IStrategy
    {
        XmlDocument documents = new XmlDocument();
        public DOM(string path)
        {
            documents.Load(path);
        }
        public List<Student> Algorithm(Student student, string path)
        {
            List<List<Student>> info = new List<List<Student>>();
            try
            {
                if (student.Speciality != null) info.Add(SearchByParam("speciality", "SPECIALITY", student.Speciality, documents, 0));
                if (student.Group != null) info.Add(SearchByParam("group", "GROUP", student.Group, documents, 1));
                if (student.Room != null) info.Add(SearchByParam("room", "ROOM", student.Room, documents, 2));
                if (student.Surname != null) info.Add(SearchByParam("surname", "SURNAME", student.Surname, documents, 3));
                if (student.Name != null) info.Add(SearchByParam("name", "NAME", student.Name, documents, 4));
            }
            catch (Exception ex)
            {


            }
            return Cross(info);
        }
        public static Student Info(XmlNode node)
        {
            Student nw = new Student();
            nw.Speciality = node.ParentNode.ParentNode.Attributes.GetNamedItem("SPECIALITY").Value;
            nw.Group = node.ParentNode.Attributes.GetNamedItem("GROUP").Value;
            nw.Room = node.Attributes.GetNamedItem("ROOM").Value;
            nw.Surname = node.Attributes.GetNamedItem("SURNAME").Value;
            nw.Name = node.Attributes.GetNamedItem("NAME").Value;
            return nw;
        }
        public static List<Student> AllStudents(XmlDocument doc)
        {
            List<Student> data2 = new List<Student>();
            XmlNodeList elem = doc.SelectNodes("//student");
            try
            {
                foreach (XmlNode el in elem)
                {
                    data2.Add(Info(el));
                }
            }
            catch { }
            return data2;

        }
        public static List<Student> SearchByParam(string nodename, string val, string param, XmlDocument doc, int i)
        {
            List<Student> students = new List<Student>();
            if (param != String.Empty && param != null)
            {
                switch (i)
                {
                    case 0:
                        {
                            XmlNodeList el = doc.SelectNodes("//" + nodename + "[@" + val + "=\"" + param + "\"]");
                            try
                            {
                                foreach (XmlNode e in el)
                                {
                                    XmlNodeList list1 = e.ChildNodes;
                                    foreach (XmlNode ell in list1)
                                    {
                                        XmlNodeList list2 = ell.ChildNodes;
                                        foreach (XmlNode elll in list2)
                                        {
                                            students.Add(Info(elll));
                                        }
                                    }
                                }
                            }
                            catch { }
                            return students;
                        }
                    case 1:
                        {
                            XmlNodeList el = doc.SelectNodes("//" + nodename + "[@" + val + "=\"" + param + "\"]");
                            try
                            {
                                foreach (XmlNode e in el)
                                {
                                    XmlNodeList list1 = e.ChildNodes;
                                    foreach (XmlNode ell in list1)
                                    {
                                        students.Add(Info(ell));
                                    }
                                }
                            }
                            catch { }
                            return students;
                        }
                    case 2:
                        {
                            XmlNodeList elem = doc.SelectNodes("//" + nodename + "[@" + val + "=\"" + param + "\"]");
                            try
                            {
                                foreach (XmlNode e in elem)
                                {
                                    students.Add(Info(e));
                                }
                            }
                            catch { }
                            return students;
                        }
                    default: break; 
                }
               

            }
            return students;
        }
        private static List<Student> Cross(List<List<Student>> list) {
            List<Student> result = new List<Student>();
            try
            {
                if (list != null)
                {
                    Student[] students = list[0].ToArray();
                    if (students != null)
                    {
                        foreach (Student elem in students)
                        {
                            bool Is = true;
                            foreach (List<Student> t in list)
                            {
                                if (t.Count <= 0) return new List<Student>();
                                foreach (Student s in t)
                                {
                                    if (elem.Comparing(s))
                                    {
                                        Is = true;
                                        break;
                                    }
                                }
                                if (!Is) break;
                            }
                            if (Is) {
                                result.Add(elem);
                            }

                        }
                      


                    }
                }
            }
            catch { }
            return result;
            }

        }
    }


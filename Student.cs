using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Student
    {
        public string Speciality = null;
        public string Room = null;
        public string Surname = null;
        public string Name = null;
        public string Group = null;
        public Student() { }
        public Student(string[] data) {
            Speciality = data[0];
            Room = data[1];
            Surname = data[2];
            Name = data[3];
            Group = data[4];
        
        }
        public Student(IStrategy info) {
            Speciality = String.Empty;
            Room = String.Empty;
            Name = String.Empty;
            Surname = String.Empty;
            Group = String.Empty;

        }
        public bool Comparing(Student student) {
            if ((this.Speciality == student.Speciality) && (this.Room == student.Room) && (this.Name == student.Name) && (this.Surname == student.Surname) && (this.Group == student.Group))
                return true;
            else return false;
            
        }
        public IStrategy Algo { get; set; }
        public List<Student> Algorithm(Student parametrs, string path) {
            return Algo.Algorithm( parametrs, path);
        }

    }
}

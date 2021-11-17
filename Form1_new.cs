﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Diagnostics;

namespace Lab2
{
    public partial class Form1 : Form
    {
        string path = "StudentBase.xml";
        List<Student> final = new List<Student>();
        
         
        private Student OurStudent() {

           Student student = new Student();


            if (checkBox1.Checked)
                student.Speciality = comboBox1.SelectedItem.ToString();

            if (checkBox2.Checked)
                student.Group = comboBox2.SelectedItem.ToString();

            if (checkBox3.Checked)
                student.Room = comboBox3.SelectedItem.ToString();

            if (checkBox4.Checked)
                student.Surname = comboBox4.SelectedItem.ToString();

            if (checkBox5.Checked)
                student.Name = comboBox5.SelectedItem.ToString();

            if (checkBox6.Checked)
                student.Mark = comboBox6.SelectedItem.ToString();

            return student;

        }
        private void Output(List<Student> final) {
            int i;
            i = 1;
            System.Console.WriteLine("Alg");
            foreach (Student n in final) {
                richTextBox1.AppendText(i++ + "." + "\n");
                richTextBox1.AppendText("Speciality " + n.Speciality + "\n");
                richTextBox1.AppendText("Group" + n.Group + "\n");
                richTextBox1.AppendText("Room" + n.Room + "\n");
                richTextBox1.AppendText("Surname" + n.Surname + "\n");
                richTextBox1.AppendText("Name" + n.Name + "\n");
                richTextBox1.AppendText("Mark" + n.Mark + "\n");
            }
        }
        public void GetAllStudents() {
            XmlDocument document = new XmlDocument();
            document.Load("StudentBase.xml");
            XmlNodeList elements = document.SelectNodes("//speciality");
            foreach (XmlNode e in elements) {
                XmlNodeList list1 = e.ChildNodes;
                foreach (XmlNode el in list1) {
                    XmlNodeList list2 = el.ChildNodes;
                    foreach (XmlNode ell in list2) {
                        string speciality = ell.ParentNode.ParentNode.Attributes.GetNamedItem("SPECIALITY").Value;
                        if (!comboBox1.Items.Contains(speciality))
                            comboBox1.Items.Add(speciality);
                        string group = ell.ParentNode.Attributes.GetNamedItem("GROUP").Value;
                        if (!comboBox2.Items.Contains(group)) 
                        comboBox2.Items.Add(group);
                        string room = ell.Attributes.GetNamedItem("ROOM").Value;
                        if (!comboBox3.Items.Contains(room))
                            comboBox3.Items.Add(room);
                        string name = ell.Attributes.GetNamedItem("NAME").Value;
                        if (!comboBox5.Items.Contains(name))
                            comboBox5.Items.Add(name);
                        string surname = ell.Attributes.GetNamedItem("SURNAME").Value;
                        if (!comboBox4.Items.Contains(surname))
                            comboBox4.Items.Add(surname);
                        string mark = ell.Attributes.GetNamedItem("MARK").Value;
                        if (!comboBox6.Items.Contains(mark))
                            comboBox6.Items.Add(mark);

                        comboBox2.Items.Add(ell.ParentNode.Attributes.GetNamedItem("GROUP").Value);
                        comboBox3.Items.Add(ell.Attributes.GetNamedItem("ROOM").Value);
                        comboBox4.Items.Add(ell.Attributes.GetNamedItem("SURNAME").Value);
                        comboBox5.Items.Add(ell.Attributes.GetNamedItem("NAME").Value);
                        comboBox6.Items.Add(ell.Attributes.GetNamedItem("MARK").Value);
                    }
                }

            }
        }
        private void ClearInput() {
        
        }
        public Form1()
        {
            InitializeComponent();
            GetAllStudents();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Student _student = OurStudent();
            if (radioButton1.Checked) {
                IStrategy CurrentStrategy = new LINQ(path);
                final = CurrentStrategy.Algorithm(_student, path);
                Output(final);
            }
            if (radioButton2.Checked) {
                IStrategy CurrentStrategy = new DOM(path);
                final = CurrentStrategy.Algorithm(_student, path);
                Output(final);
            }
            if (radioButton3.Checked) {
                IStrategy CurrentStrategy = new SAX(path);
                final = CurrentStrategy.Algorithm(_student, path);
                Output(final);
            }

        }
       

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            checkBox1.Checked = false;
            comboBox1.Text = null;
            checkBox2.Checked = false;
            comboBox2.Text = null;
            checkBox3.Checked = false;
            comboBox3.Text = null;
            checkBox4.Checked = false;
            comboBox4.Text = null;
            checkBox5.Checked = false;
            comboBox5.Text = null;
            checkBox6.Checked = false;
            comboBox6.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("XSL.xsl");
            string input = @"StudentBase.xml";
            string result = @"info.html";
            xslt.Transform(input, result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\User\source\repos\Lab2\Lab2\bin\Debug\info.html");
        }
    }
}

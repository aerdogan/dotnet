using System;
using System.Collections.Generic;

namespace MediatorPattern
{
    class Program
    {

        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher teacher = new Teacher(mediator);
            teacher.Name = "teacher name";
            mediator.Teacher = teacher;

            Student student1 = new Student(mediator);
            student1.Name = "student 1";

            Student student2 = new Student(mediator);
            student2.Name = "student 2";

            mediator.Students = new List<Student> { student1, student2 };

            teacher.SendNewImageUrl("Slide1.jpg");
            teacher.ReceiveQuestion("is it true?", student1);
            teacher.AnswerQuestion("Yes.", student1);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        

        public void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0},{1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}", student.Name, answer);
            Mediator.SendAnswer(answer, student);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public string Name { get; set; }

        public void ReceiveImage(string url)
        {
            Console.WriteLine("{1} received image : {0}", url, Name);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine("{1} received answer : {0}", answer, Name);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }

    }
}

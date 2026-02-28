using System;
using System.Collections.Generic;

namespace Day10
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<Subject> EnrolledSubjects { get; set; }

        public Student(int studentId, string studentName)
        {
            StudentId = studentId;
            StudentName = studentName;
            EnrolledSubjects = new List<Subject>();
        }

        public void EnrollSubject(Subject subject)
        {
            if (!EnrolledSubjects.Contains(subject))
                EnrolledSubjects.Add(subject);
        }

        public void OnExamStarting(object sender, ExamEventArgs e)
        {
            Exam exam = sender as Exam;
            if (IsEnrolledInSubject(exam.Subject))
            {
                Console.WriteLine($"[NOTIFICATION] Student {StudentName}: {e.ToString()}");
            }
        }

        private bool IsEnrolledInSubject(Subject subject)
        {
            return EnrolledSubjects.Contains(subject);
        }

        public override string ToString()
        {
            return $"Student ID: {StudentId}, Name: {StudentName}";
        }
    }
}

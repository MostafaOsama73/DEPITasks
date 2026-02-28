using Day10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create subjects
            Subject mathSubject = new Subject(1, "Mathematics");
            Subject englishSubject = new Subject(2, "English");

            // Create students
            Student student1 = new Student(101, "Ali Ahmed");
            Student student2 = new Student(102, "Fatima Hassan");
            Student student3 = new Student(103, "Omar Mohamed");

            // Enroll students in subjects
            student1.EnrollSubject(mathSubject);
            student1.EnrollSubject(englishSubject);
            student2.EnrollSubject(mathSubject);
            student3.EnrollSubject(englishSubject);

            Console.WriteLine("========================================");
            Console.WriteLine("         EXAMINATION SYSTEM");
            Console.WriteLine("========================================\n");

            // Create Practice Exam for Mathematics
            PracticeExam practiceExam = new PracticeExam(1, 60, 3, mathSubject);
            practiceExam.Questions = new QuestionList("PracticeExamQuestions.txt");

            // Create Final Exam for English
            FinalExam finalExam = new FinalExam(2, 90, 2, englishSubject);
            finalExam.Questions = new QuestionList("FinalExamQuestions.txt");

            // Clear previous log files
            practiceExam.Questions.ClearLogFile();
            finalExam.Questions.ClearLogFile();

            Console.WriteLine("1. Creating Practice Exam Questions...\n");
            CreatePracticeExamQuestions(practiceExam);

            Console.WriteLine("\n2. Creating Final Exam Questions...\n");
            CreateFinalExamQuestions(finalExam);

            Console.WriteLine("\n========================================");
            Console.WriteLine("         EXAM SELECTION");
            Console.WriteLine("========================================\n");

            Console.WriteLine("Select Exam Type:");
            Console.WriteLine("1. Practice Exam (Mathematics)");
            Console.WriteLine("2. Final Exam (English)");
            Console.Write("Enter your choice (1 or 2): ");

            string choice = Console.ReadLine();

            // Subscribe students to exam events
            if (choice == "1")
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("      PRACTICE EXAM PREPARATION");
                Console.WriteLine("========================================");

                // Subscribe students enrolled in Math
                practiceExam.OnExamStarting += student1.OnExamStarting;
                practiceExam.OnExamStarting += student2.OnExamStarting;

                // Start the exam
                Console.WriteLine("\nStarting Practice Exam for Mathematics...\n");
                practiceExam.ChangeMode(ExamMode.Starting);

                // Display exam
                practiceExam.ShowExam();
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("       FINAL EXAM PREPARATION");
                Console.WriteLine("========================================");

                // Subscribe students enrolled in English
                finalExam.OnExamStarting += student1.OnExamStarting;
                finalExam.OnExamStarting += student3.OnExamStarting;

                // Start the exam
                Console.WriteLine("\nStarting Final Exam for English...\n");
                finalExam.ChangeMode(ExamMode.Starting);

                // Display exam
                finalExam.ShowExam();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine("         LOGGED QUESTIONS");
            Console.WriteLine("========================================\n");

            if (choice == "1")
            {
                Console.WriteLine("Questions from Practice Exam Log:\n");
                practiceExam.Questions.DisplayQuestionsFromFile();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Questions from Final Exam Log:\n");
                finalExam.Questions.DisplayQuestionsFromFile();
            }

            Console.WriteLine("\n========================================");
            Console.WriteLine("     CLONING AND COMPARISON TEST");
            Console.WriteLine("========================================\n");

            TestCloningAndComparison(mathSubject, practiceExam, finalExam);

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }

        static void CreatePracticeExamQuestions(PracticeExam exam)
        {
            // True/False Question
            TrueOrFalseQuestion q1 = new TrueOrFalseQuestion(
                "Question 1",
                "2 + 2 = 4",
                10,
                true
            );
            exam.Questions.Add(q1);

            // Choose One Question
            List<string> choices2 = new List<string> { "10", "15", "20", "25" };
            ChooseOneQuestion q2 = new ChooseOneQuestion(
                "Question 2",
                "5 + 5 = ?",
                10,
                choices2,
                2 // Index 2 is "20"
            );
            exam.Questions.Add(q2);

            // Choose All Question
            List<string> choices3 = new List<string> { "2", "3", "4", "5", "6" };
            List<int> correctAnswers = new List<int> { 0, 2 }; // 2 and 4 are even
            ChooseAllQuestion q3 = new ChooseAllQuestion(
                "Question 3",
                "Select all even numbers:",
                10,
                choices3,
                correctAnswers
            );
            exam.Questions.Add(q3);

            Console.WriteLine("Added 3 questions to Practice Exam");
            Console.WriteLine($"Total Questions: {exam.Questions.Count}");
        }

        static void CreateFinalExamQuestions(FinalExam exam)
        {
            // True/False Question
            TrueOrFalseQuestion q1 = new TrueOrFalseQuestion(
                "Question 1",
                "The capital of France is Paris",
                15,
                true
            );
            exam.Questions.Add(q1);

            // Choose One Question
            List<string> choices2 = new List<string> { "Yes", "No", "Maybe" };
            ChooseOneQuestion q2 = new ChooseOneQuestion(
                "Question 2",
                "Is English a global language?",
                15,
                choices2,
                0 // Index 0 is "Yes"
            );
            exam.Questions.Add(q2);

            Console.WriteLine("Added 2 questions to Final Exam");
            Console.WriteLine($"Total Questions: {exam.Questions.Count}");
        }

        static void TestCloningAndComparison(Subject subject, PracticeExam practiceExam, FinalExam finalExam)
        {
            // Test cloning
            Console.WriteLine("Testing Clone on Subject:");
            Subject clonedSubject = (Subject)subject.Clone();
            Console.WriteLine($"Original: {subject}");
            Console.WriteLine($"Cloned:   {clonedSubject}");
            Console.WriteLine($"Are they equal? {subject.Equals(clonedSubject)}");
            Console.WriteLine($"Are they the same object? {ReferenceEquals(subject, clonedSubject)}\n");

            // Test cloning on Exams
            Console.WriteLine("Testing Clone on Practice Exam:");
            PracticeExam clonedPracticeExam = (PracticeExam)practiceExam.Clone();
            Console.WriteLine($"Original: {practiceExam}");
            Console.WriteLine($"Cloned:   {clonedPracticeExam}");
            Console.WriteLine($"Are they equal? {practiceExam.Equals(clonedPracticeExam)}\n");

            // Test comparison
            Console.WriteLine("Testing CompareTo:");
            int comparison = practiceExam.CompareTo(finalExam);
            if (comparison < 0)
                Console.WriteLine($"Practice Exam ID ({practiceExam.ExamId}) < Final Exam ID ({finalExam.ExamId})");
            else if (comparison > 0)
                Console.WriteLine($"Practice Exam ID ({practiceExam.ExamId}) > Final Exam ID ({finalExam.ExamId})");
            else
                Console.WriteLine($"Both exams have the same ID");

            Console.WriteLine();

            // Test GetHashCode
            Console.WriteLine("Testing GetHashCode:");
            Console.WriteLine($"Practice Exam Hash Code: {practiceExam.GetHashCode()}");
            Console.WriteLine($"Final Exam Hash Code:    {finalExam.GetHashCode()}");
        }
    
    }
}

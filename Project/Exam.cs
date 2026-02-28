using System;
using System.Collections.Generic;

namespace Day10
{
    public enum ExamMode
    {
        Starting,
        Queued,
        Finished
    }

    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int ExamId { get; set; }
        public int TimeInMinutes { get; set; }
        public int NumberOfQuestions { get; set; }
        public QuestionList Questions { get; set; }
        public Dictionary<int, int> QuestionAnswerDictionary { get; set; }
        public Subject Subject { get; set; }
        public ExamMode Mode { get; set; }

        protected Exam(int examId, int timeInMinutes, int numberOfQuestions, Subject subject)
        {
            ExamId = examId;
            TimeInMinutes = timeInMinutes;
            NumberOfQuestions = numberOfQuestions;
            Subject = subject;
            Mode = ExamMode.Starting;
            QuestionAnswerDictionary = new Dictionary<int, int>();
        }

        public abstract void ShowExam();

        public virtual int CompareTo(Exam other)
        {
            if (other == null) return 1;
            return this.ExamId.CompareTo(other.ExamId);
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Exam)) return false;
            var other = obj as Exam;
            return this.ExamId == other.ExamId;
        }

        public override int GetHashCode()
        {
            return ExamId.GetHashCode();
        }

        public override string ToString()
        {
            return $"Exam ID: {ExamId}, Time: {TimeInMinutes} min, Questions: {NumberOfQuestions}, Subject: {Subject.SubjectName}, Mode: {Mode}";
        }

        public void ChangeMode(ExamMode newMode)
        {
            Mode = newMode;
            if (Mode == ExamMode.Starting)
            {
                NotifyStudents();
            }
        }

        protected virtual void NotifyStudents()
        {
            OnExamStarting?.Invoke(this, new ExamEventArgs { Message = $"Exam {ExamId} for {Subject.SubjectName} is starting!" });
        }

        public event EventHandler<ExamEventArgs> OnExamStarting;
    }

    public class PracticeExam : Exam
    {
        public PracticeExam(int examId, int timeInMinutes, int numberOfQuestions, Subject subject)
            : base(examId, timeInMinutes, numberOfQuestions, subject)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("\n================ PRACTICE EXAM ================");
            Console.WriteLine(this.ToString());
            Console.WriteLine("Subject: " + Subject.ToString());
            Console.WriteLine("\nQuestions:");

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}:");
                Console.WriteLine(Questions[i].ToString());
            }

            Console.WriteLine("\n================ ANSWERS ================");
            Console.WriteLine("Right answers are shown below:");
            // In a real scenario, this would show the correct answers
            Console.WriteLine("(Practice Exam shows answers after completion)");
        }

        public override object Clone()
        {
            return new PracticeExam(this.ExamId, this.TimeInMinutes, this.NumberOfQuestions, (Subject)this.Subject.Clone());
        }
    }

    public class FinalExam : Exam
    {
        public FinalExam(int examId, int timeInMinutes, int numberOfQuestions, Subject subject)
            : base(examId, timeInMinutes, numberOfQuestions, subject)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("\n================ FINAL EXAM ================");
            Console.WriteLine(this.ToString());
            Console.WriteLine("Subject: " + Subject.ToString());
            Console.WriteLine("\nQuestions:");

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}:");
                Console.WriteLine(Questions[i].ToString());
            }

            Console.WriteLine("\n(Final Exam - Answers will be revealed after submission)");
        }

        public override object Clone()
        {
            return new FinalExam(this.ExamId, this.TimeInMinutes, this.NumberOfQuestions, (Subject)this.Subject.Clone());
        }
    }
}

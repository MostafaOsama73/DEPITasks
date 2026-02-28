using System;
using System.Collections.Generic;

namespace Day10
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }

        protected Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
        }

        public abstract override string ToString();

        public virtual int CompareTo(Question other)
        {
            if (other == null) return 1;
            return this.Marks.CompareTo(other.Marks);
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Question)) return false;
            var other = obj as Question;
            return this.Header == other.Header && this.Body == other.Body && this.Marks == other.Marks;
        }

        public override int GetHashCode()
        {
            return (Header + Body + Marks).GetHashCode();
        }
    }

    public class TrueOrFalseQuestion : Question
    {
        public bool Answer { get; set; }

        public TrueOrFalseQuestion(string header, string body, int marks, bool answer)
            : base(header, body, marks)
        {
            Answer = answer;
        }

        public override string ToString()
        {
            return $"[True/False] Header: {Header}\nBody: {Body}\nMarks: {Marks}\nAnswer: {Answer}\n";
        }

        public override object Clone()
        {
            return new TrueOrFalseQuestion(this.Header, this.Body, this.Marks, this.Answer);
        }
    }

    public class ChooseOneQuestion : Question
    {
        public List<string> Choices { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public ChooseOneQuestion(string header, string body, int marks, List<string> choices, int correctAnswerIndex)
            : base(header, body, marks)
        {
            Choices = choices;
            CorrectAnswerIndex = correctAnswerIndex;
        }

        public override string ToString()
        {
            string result = $"[Choose One] Header: {Header}\nBody: {Body}\nMarks: {Marks}\nChoices:\n";
            for (int i = 0; i < Choices.Count; i++)
            {
                result += $"  {i + 1}. {Choices[i]}\n";
            }
            return result;
        }

        public override object Clone()
        {
            return new ChooseOneQuestion(this.Header, this.Body, this.Marks, 
                new List<string>(this.Choices), this.CorrectAnswerIndex);
        }
    }

    public class ChooseAllQuestion : Question
    {
        public List<string> Choices { get; set; }
        public List<int> CorrectAnswersIndices { get; set; }

        public ChooseAllQuestion(string header, string body, int marks, List<string> choices, List<int> correctAnswersIndices)
            : base(header, body, marks)
        {
            Choices = choices;
            CorrectAnswersIndices = correctAnswersIndices;
        }

        public override string ToString()
        {
            string result = $"[Choose All] Header: {Header}\nBody: {Body}\nMarks: {Marks}\nChoices:\n";
            for (int i = 0; i < Choices.Count; i++)
            {
                result += $"  {i + 1}. {Choices[i]}\n";
            }
            return result;
        }

        public override object Clone()
        {
            return new ChooseAllQuestion(this.Header, this.Body, this.Marks, 
                new List<string>(this.Choices), new List<int>(this.CorrectAnswersIndices));
        }
    }
}

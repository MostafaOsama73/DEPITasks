using System;
using System.Collections.Generic;

namespace Day10
{
    public class Answer
    {
        public int QuestionId { get; set; }
        public object StudentAnswer { get; set; }

        public Answer(int questionId, object studentAnswer)
        {
            QuestionId = questionId;
            StudentAnswer = studentAnswer;
        }

        public override string ToString()
        {
            return $"Question ID: {QuestionId}, Student Answer: {StudentAnswer}";
        }
    }

    public class AnswerList : List<Answer>
    {
        public AnswerList() : base() { }

        public void AddAnswer(int questionId, object studentAnswer)
        {
            this.Add(new Answer(questionId, studentAnswer));
        }

        public Answer GetAnswerByQuestionId(int questionId)
        {
            return this.Find(a => a.QuestionId == questionId);
        }
    }
}

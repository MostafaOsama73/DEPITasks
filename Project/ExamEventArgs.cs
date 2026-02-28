using System;

namespace Day10
{
    public class ExamEventArgs : EventArgs
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }

        public ExamEventArgs()
        {
            CreatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{CreatedAt}] {Message}";
        }
    }
}

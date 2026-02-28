using System;

namespace Day10
{
    public class Subject : ICloneable, IComparable<Subject>
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Subject Name: {SubjectName}";
        }

        public int CompareTo(Subject other)
        {
            if (other == null) return 1;
            return this.SubjectId.CompareTo(other.SubjectId);
        }

        public object Clone()
        {
            return new Subject(this.SubjectId, this.SubjectName);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Subject)) return false;
            var other = obj as Subject;
            return this.SubjectId == other.SubjectId && this.SubjectName == other.SubjectName;
        }

        public override int GetHashCode()
        {
            return (SubjectId + SubjectName).GetHashCode();
        }
    }
}

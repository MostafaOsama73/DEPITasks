using System;
using System.Collections.Generic;
using System.IO;

namespace Day10
{
    public class QuestionList : List<Question>
    {
        private string _filePath;

        public QuestionList(string filePath)
        {
            _filePath = filePath;
        }

        public new void Add(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            base.Add(question);
            LogQuestionToFile(question);
        }

        private void LogQuestionToFile(Question question)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, true))
                {
                    writer.WriteLine("================================");
                    writer.WriteLine(question.ToString());
                    writer.WriteLine("================================");
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging question to file: {ex.Message}");
            }
        }

        public void ClearLogFile()
        {
            try
            {
                if (File.Exists(_filePath))
                    File.Delete(_filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing log file: {ex.Message}");
            }
        }

        public void DisplayQuestionsFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("Log file does not exist.");
                    return;
                }

                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading log file: {ex.Message}");
            }
        }
    }
}

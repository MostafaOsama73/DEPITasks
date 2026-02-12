using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal interface IReadable
    {
        void Read();
    }

    internal interface IWritable
    {
        void Write(string content);
    }

    public class File : IReadable , IWritable
    {
        public string FileName { get; set; }
        private string _content = "";

        public File(string name)
        {
            FileName = name;
        }

        public void Read()
        {
            if (string.IsNullOrEmpty(_content))
            {
                Console.WriteLine($"Reading {FileName}: [Empty File]");
            }
            else
            {
                Console.WriteLine($"Reading {FileName}: {_content}");
            }
        }

        // Implementation of IWritable.Write()
        public void Write(string content)
        {
            _content = content;
            Console.WriteLine($"Writing to {FileName}: \"{content}\"");
        }

    }
}

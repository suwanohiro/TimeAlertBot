using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeAlertBot
{
    public class FileAction
    {
        private static string ConvertFileLink(string currentFilePath)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string fullPath = Path.GetFullPath(Path.Combine(baseDir, currentFilePath));
            return fullPath;
        }

        public static string Read(string currentFilePath)
        {
            string path = ConvertFileLink(currentFilePath);
            string result = File.ReadAllText(path, Encoding.UTF8);
            return result;
        }

        public static string[][] ReadCSV(string currentFilePath)
        {
            string textData = Read(currentFilePath);
            string[] lines = textData.Split('\n');
            string[][] result = new string[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                result[i] = lines[i].Split(',');
            }
            return result;
        }

        private static void Write(string currentFilePath, string writeString, string fileReadMode)
        {
            string path = ConvertFileLink(currentFilePath);
            if (fileReadMode == "w")
            {
                File.WriteAllText(path, writeString, Encoding.UTF8);
            }
            else if (fileReadMode == "a")
            {
                File.AppendAllText(path, writeString, Encoding.UTF8);
            }
        }

        public static void WriteAdd(string currentFilePath, string writeString)
        {
            Write(currentFilePath, writeString, "a");
        }

        public static void WriteNew(string currentFilePath, string writeString)
        {
            Write(currentFilePath, writeString, "w");
        }

        public static void Clear(string currentFilePath)
        {
            WriteNew(currentFilePath, "");
        }
    }
}

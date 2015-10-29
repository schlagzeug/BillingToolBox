using System;
using System.IO;

namespace BillingToolBox.Classes
{
    public static class Log
    {
        private static StreamWriter _writer;
        private static string LogDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

        private static string FilePath
        {
            get { return Path.Combine(LogDirectory, string.Format("log{0}.txt", DateTime.Today.ToString("MMddyy"))); }
        }

        public static void WriteToLog(string format, params object[] args)
        {
            if (CheckLogFile())
                _writer.WriteLine(string.Format(format, args));
        }

        private static bool CheckLogFile()
        {
            try
            {
                if (!Directory.Exists(LogDirectory))
                    Directory.CreateDirectory(LogDirectory);
                if (!File.Exists(FilePath))
                    _writer = new StreamWriter(File.Create(FilePath));
                if (_writer == null)
                    _writer = new StreamWriter(FilePath, true);
                _writer.AutoFlush = true;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static void CloseLog()
        {
            if (_writer != null)
            {
                _writer.Flush();
                _writer.Close();
            }
        }

        internal static void OpenCurrentLogFile()
        {
            if (File.Exists(FilePath))
            {
                Tools.OpenFile(FilePath);
            }
            else
            {
                OpenLogDirectory();
            }
        }

        public static void OpenLogDirectory()
        {
            Tools.OpenDirectory(LogDirectory);
        }
    }
}

namespace E_Services_Portal
{
    using System;
    using System.IO;

    public static class Logger
    {
        private static readonly object lockObject = new object();
        private static readonly string logFolderPath = "logs";
        private static StreamWriter logStreamWriter;

        public static void Log(string message)
        {
            lock (lockObject) // make the logging operation thread-safe
            {
                try
                {
                    // Create log folder if it doesn't exist
                    if (!Directory.Exists(logFolderPath))
                    {
                        Directory.CreateDirectory(logFolderPath);
                    }

                    // Create new log file if it's a new day
                    if (logStreamWriter == null || logStreamWriter.BaseStream == null || DateTime.Now.Date > File.GetCreationTime(logStreamWriter.BaseStream.ToString()).Date)
                    {
                        CloseLogStreamWriter();
                        string logFileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                        string logFilePath = Path.Combine(logFolderPath, logFileName);
                        logStreamWriter = new StreamWriter(logFilePath, true);
                    }

                    // Write log message to the file
                    string logMessage = string.Format("{0} - {1}", DateTime.Now, message);
                    logStreamWriter.WriteLine(logMessage);
                    logStreamWriter.Flush();
                }
                catch (Exception ex)
                {
                    // handle the exception or re-throw it
                    Console.WriteLine($"Error writing log message: {ex.Message}");
                }
            }
        }

        private static void CloseLogStreamWriter()
        {
            try
            {
                if (logStreamWriter != null)
                {
                    logStreamWriter.Close();
                    logStreamWriter.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing log file: {ex.Message}");
            }
        }

        public static void Close()
        {
            CloseLogStreamWriter();
        }
    }

}

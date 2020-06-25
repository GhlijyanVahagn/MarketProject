using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketLogger
{
    public static class ExceptionLogger
    {
        private static StringBuilder  logBuilder;
        private static string fileName { get { return "ExceptionLogs.txt"; } }
        private static string logFullPath { get { return AppDomain.CurrentDomain.BaseDirectory + fileName; } }
        private static int innerExceptionCoutns;

        static ExceptionLogger()
        {
             innerExceptionCoutns = 0;
        }

       
        public static void log(Exception exception)
        {

           
            object locker = new object();
            lock(locker)
            { 
 
                logBuilder = new StringBuilder();
                var logMessage = logMessageCreator(exception);
                logWriter(logMessage);
                innerExceptionCoutns = 0;
            }
        }

        private static string logMessageCreator(Exception exception)
        {
            logBuilder.Append($"{new string('\t', innerExceptionCoutns)}Message:\t {exception.Message}\n");
            logBuilder.Append($"{new string('\t', innerExceptionCoutns)}Source:\t {exception.Source}\n");
            logBuilder.Append($"{new string('\t', innerExceptionCoutns)}Data:\t {exception.Data}\n");
            logBuilder.Append($"{new string('\t', innerExceptionCoutns)}StackTrace:\t {exception.StackTrace}\n");
            logBuilder.Append($"{new string('\t', innerExceptionCoutns)}HelpLink:\t {exception.HelpLink}\n");
            logBuilder.Append($"{new string('\t', innerExceptionCoutns)}DateAndTime:\t {DateTime.Now}\n");
            logBuilder.Append($"{new string('\t', innerExceptionCoutns)}Thread_Id:\t {Thread.CurrentThread.ManagedThreadId}\n");
            logBuilder.AppendLine();

            if (exception.InnerException != null)
            {
                innerExceptionCoutns++;
                logBuilder.Append('\t',innerExceptionCoutns);
                logMessageCreator(exception.InnerException);

            }
            logBuilder.Append(new string('-', 20));
            return logBuilder.ToString();
            

        }
        private static  void logWriter(string logMessage)
        {
            if (!File.Exists(logFullPath))
            {
                var fstream = File.Create(logFullPath);
                fstream.Close();

            }

                using (var file = File.Open(logFullPath, FileMode.Append, FileAccess.Write))
                {
                    using (var writer = new StreamWriter(file))
                    {
                        writer.WriteLine(logMessage);
                        writer.Flush();
                    }
                }
            logBuilder = null;

        }

    }
}

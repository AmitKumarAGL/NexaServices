using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
using System.IO;
using System.Configuration;
using DMS.DataService.DataContract;
using DMS.DataService.DataLayer;


namespace DMS.DataService.LogHelper
{
   public static class Logging
    {
       // private static ILog logger = LogManager.GetLogger(typeof(Logging));

        public static void InitializeConfiguration()
        {
           // XmlConfigurator.Configure();
        }

        public static void Error(Exception ex)
        {
            Error(ex, null);
        }

        public static void Error(Exception aEx, string log)
        {
            StringBuilder s = new StringBuilder();
            Exception ex = aEx;
            if (log != null)
            {
                s.Append("Message: " + log + Environment.NewLine);
            }

            while (null != ex)
            {
                s.Append("Message:" + ex.Message + "\n");
                s.Append("StackTrace:" + ex.StackTrace + "\n");
                s.Append("Full Error Details: " + ex.ToString() + Environment.NewLine);
               // s.Append("InnerException: " + ex.InnerException != null ? ex.InnerException.ToString() : Environment.NewLine);
                ex = ex.InnerException;
            }
           // logger.Error(s.ToString());
            LogFileWrite(s.ToString());//To write log file.
           
        }

        public static void Warn(string log)
        {
           // logger.Warn(log);
        }

        public static void Info(string log)
        {
           // logger.Info(log);
        }

        public static void Fatal(string log)
        {
           // logger.Fatal(log);
        }

        public static void Debug(string log)
        {
           // logger.Debug(log);
        }

        public static void LogFileWrite(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {

                string logFilePath = DmsDL.SiteUrl; //"c:\\LogError\\";

                logFilePath = logFilePath + "ProgramLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

                if (logFilePath.Equals("")) return;
                #region Create the Log file directory if it does not exists
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                #endregion Create the Log file directory if it does not exists

                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(message);
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }

        }
    }
}

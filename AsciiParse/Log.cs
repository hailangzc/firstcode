using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AsciiParse
{
    public  class Log
    {
        public static void WriteLog(Exception Ex)
        {
            //String s;
            string ErrTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string ErrSource = Ex.Source;
            string ErrTargetSite = Ex.TargetSite.ToString();
            string ErrMsg = Ex.Message;
            string ErrStackTrace = Ex.StackTrace;
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"\\ErrorLog\\";
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            string FileName = FilePath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (GetFileSize(FileName) > 1024 * 3)
            {
                CopyToBak(FileName);
            }
            StreamWriter MySw = new StreamWriter(FileName, true);
            MySw.WriteLine("错误时间 : " + ErrTime);
            MySw.WriteLine("错误对象 : " + ErrSource);
            MySw.WriteLine("异常方法 : " + ErrTargetSite);
            MySw.WriteLine("错误信息 : " + ErrMsg);
            MySw.WriteLine("堆栈内容 : ");
            MySw.WriteLine(ErrStackTrace);
            MySw.WriteLine("\r\n*****************Qindeke*Error*Report*****************\r\n");
            MySw.Close();
            //MySw.Dispose();
        }

        private static long GetFileSize(string FileName)
        {
            long strRe = 0;
            if (File.Exists(FileName))
            {
                FileStream MyFs = new FileStream(FileName, FileMode.Open);
                strRe = MyFs.Length / 1024;
                MyFs.Close();
                MyFs.Dispose();
            }
            return strRe;
        }

        private static void CopyToBak(string sFileName)
        {
            int FileCount = 0;
            string sBakName = "";
            do
            {
                FileCount++;
                sBakName = sFileName + "." + FileCount.ToString() + ".BAK";
            }
            while (File.Exists(sBakName));
            File.Copy(sFileName, sBakName);
            File.Delete(sFileName);
        }

        /// <summary>
        /// 添加日志信息
        /// </summary>
        /// <param name="Message"></param>
        public static void SetLogMessage(string Message)
        {
            string ErrTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string ErrMsg = Message;
            string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"\\LogReport\\";
            if (!Directory.Exists(FilePath))
            {
                Directory.CreateDirectory(FilePath);
            }
            string FileName = FilePath + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (GetFileSize(FileName) > 1024 * 3)
            {
                CopyToBak(FileName);
            }
            StreamWriter swlog = new StreamWriter(FileName, true);
            swlog.WriteLine("" + ErrTime);
            swlog.WriteLine("" + ErrMsg);
            swlog.WriteLine("\r\n");
            swlog.Flush();
            swlog.Close();
        }
    }
}

using System;
using System.IO;
using System.Text;
namespace BaoCaoLuong2018.BaoCaoLuonng2017.MyLog
{
    internal class LogFile
    {
        public static void Log(string logMessage, TextWriter w)
        {
            //w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
            DateTime.Now.ToLongDateString());
            w.WriteLine(" : ");
            w.WriteLine("{0}", logMessage);
            //w.WriteLine("-------------------------------");
        }

        public static void WriteLog(String fileName_username, String LogText)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(fileName_username, FileMode.Append);
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8, 512))
                {
                    Log(LogText, writer);
                    //Global.DAL.ExecuteLogFile("INSERT INTO [dbo].[tbl_LogFile]([Username],[Info],[DateLog]) VALUES('" + fileName_username + "','" + LogText + "',Getdate())");
                    //writer.Write(LogText);
                }
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }

            using (StreamWriter w = File.AppendText(fileName_username))
            {
                Log(LogText, w);
            }
        }
    }
}

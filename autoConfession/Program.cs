using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using System.IO;

namespace autoConfession
{
    static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());


            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleUnhandledException);

            Application.ThreadException += new  ThreadExceptionEventHandler(HandleUnhandledThreadException);

            BasicConfigurator.Configure();
        }

        static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        { 
            Exception ex = (Exception)e.ExceptionObject;    
            writeErrorToFile(ex);
        }

        static void HandleUnhandledThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = (Exception)e.Exception;        
            writeErrorToFile(ex);
        }

        private static void writeErrorToFile(Exception ex)
        {
            var dir = @"C:\Temp\log";  // folder location

            if (!Directory.Exists(dir))  // if it doesn't exist, create
                Directory.CreateDirectory(dir);

            string exceptionText = ex.Message + Environment.NewLine + ex.StackTrace;
            File.WriteAllText(dir, exceptionText);
        }
    }
}

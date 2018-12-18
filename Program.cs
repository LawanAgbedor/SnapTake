using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL;

namespace SnapTake
{
    class Program
    {
        private static Logger<Program> log = new Logger<Program>();

        private static Mutex mutex;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Set up our logging
            //
            log4net.Config.XmlConfigurator.Configure();

            bool createdNew;
            mutex = new Mutex(true, "9jaHealth-Application-Mutex", out createdNew);
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    Application.Run(new frmPictureCapture());
                }
                catch (Exception e)
                {
                    log.LogFatal("Application terminated with Exception.", null, e);
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            else
            {
                var msg = "An instance is already running!";
                log.LogFatal(msg);
                MessageBox.Show(msg);
            }
        }
    }
}

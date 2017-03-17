using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarvisDB;
using System.Windows;
using System.Reflection;
using System.Threading;
namespace Starvis.Utilities
{
    class CommandExecution
    {
        public static string clipText;
        public void Run (int rowID)
        {
            var db = new Models();
            var url = db.WebDB.Where(w => w.WebID == rowID).FirstOrDefault().URL;
            var cmd = "start chrome " + url;
            Batch.ExecuteCommandAsync(cmd);
        }
        [STAThread]
        public void CopyToClipBoard(int rowID)
        {
            var db = new Models();
            clipText = db.HotKeyDB.Where(w => w.HotKeyID == rowID).FirstOrDefault().Value;
            //Invoke((Action)(() => { Clipboard.SetText(text) }));

            Thread staThread = new Thread(new ThreadStart(myMethod));
            staThread.ApartmentState = ApartmentState.STA;
            staThread.Start();
        }
        public static void myMethod()
        {
            Clipboard.SetText(clipText);
        }

    }
}

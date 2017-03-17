using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarvisDB;
using Starvis.Utilities;

namespace Starvis
{
    class RunCommands
    {
        public void OpenUrl(int rowID)
        {
            var db = new Models();
            string Url = db.WebDB.Where(w => w.WebID == rowID).FirstOrDefault().URL;
            string cmd = "start chrome " + Url;
            Batch.ExecuteCommandAsync(cmd);
        }
    }
}

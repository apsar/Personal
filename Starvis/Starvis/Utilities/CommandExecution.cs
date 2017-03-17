using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarvisDB;

namespace Starvis.Utilities
{
    class CommandExecution
    {
        public void Run (int rowID)
        {
            var db = new Models();
            var url = db.WebDB.Where(w => w.WebID == rowID).FirstOrDefault().URL;
            var cmd = "start chrome " + url;
            Batch.ExecuteCommandAsync(cmd);
        }
    }
}

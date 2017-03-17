using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StarvisDB;
using Starvis;

namespace Starvis
{
    public class BaseWindow
    {
        public void SettingsInsertUpdate(string key,string value)
        {
            using (Models db = new Models())
            {
                Models models = new Models();
                SettingsDB rec = models.SettingsDB.Where(q => q.Key == key).FirstOrDefault();

                if (rec == null)
                {
                    SettingsDB newRecord = new SettingsDB { Key = key, Value = value };
                    db.SettingsDB.Add(newRecord);
                    db.SaveChanges();
                }
                else
                {
                    rec.Key = key;
                    rec.Value = value;
                    db.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public void JIRAInsertUpdate(string projectType,string URL,string textCommand,string voiceCommand)
        {
            using (Models db = new Models())
            {
                Models models = new Models();
                JIRADB newRecord = new JIRADB { ProjectType = projectType, URL = URL, TextCommand = textCommand, VoiceCommand = voiceCommand };
                db.JIRADB.Add(newRecord);
                db.SaveChanges();
            }
        }

        public string GetCurrentModeType()
        {
            Models models = new Models();
            SettingsDB rec = models.SettingsDB.Where(q => q.Key == "Mode").FirstOrDefault();
            if (rec != null)
                return rec.Value;

            return null;
        }

        public void OutlookInsert(OutlookDB row)
        {
            using (Models db = new Models())
            {
                Models models = new Models();
                db.OutlookDB.Add(row);
                db.SaveChanges();
            }
        }
    }
}

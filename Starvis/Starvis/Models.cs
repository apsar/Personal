using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StarvisDB
{
    public class Models : DbContext
    {
        public DbSet<ArenaDB> ArenaDB { get; set; }
        public DbSet<ProfileDB> ProfileDB { get; set; }
        public DbSet<WebDB> WebDB { get; set; }
        public DbSet<HotKeyDB> HotKeyDB { get; set; }
        public DbSet<OutlookDB> OutlookDB { get; set; }
        public DbSet<JIRADB> JIRADB { get; set; }
        public DbSet<CodeBaseDB> CodeBaseDB { get; set; }
        public DbSet<SettingsDB> SettingsDB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Starvis.db");
        }
    }

    public class ArenaDB
    {
        [Key]
        public int ArenaID { get; set; }
        public string Name { get; set; }
        public string AppList { get; set; }
        public string TextCommand { get; set; }
        public string VoiceCommand { get; set; }
    }

    public class ProfileDB
    {
        [Key]
        public int ProfileDBID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ContrastValue { get; set; }
        public int BrightnessValue { get; set; }
        public int Volume { get; set; }
        public string TextCommand { get; set; }
        public string VoiceCommand { get; set; }
    }

    public class WebDB
    {
        [Key]
        public int WebID { get; set; }
        public string URL { get; set; }
        public string TextCommand { get; set; }
        public string VoiceCommand { get; set; }
    }

    public class HotKeyDB
    {
        [Key]
        public int HotKeyID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string TextCommand { get; set; }
        public string VoiceCommand { get; set; }
    }

    public class OutlookDB
    {
        [Key]
        public int OutlookID { get; set; }
        public string Type { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int UnReadMailCount { get; set; }
        public string SearchKey { get; set; }
        public string TextCommand { get; set; }
        public string VoiceCommand { get; set; }
    }

    public class JIRADB
    {
        [Key]
        public int JIRAID { get; set; }
        public string ProjectType { get; set; }
        public string URL { get; set; }
        public string TextCommand { get; set; }
        public string VoiceCommand { get; set; }
    }

    public class CodeBaseDB
    {
        [Key]
        public int CodeBaseID { get; set; }
        public string CommandType { get; set; }
        public string ActualCommand { get; set; }
        public string TextCommand { get; set; }
        public string VoiceCommand { get; set; }
    }

    public class SettingsDB
    {
        [Key]
        public int SettingsID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

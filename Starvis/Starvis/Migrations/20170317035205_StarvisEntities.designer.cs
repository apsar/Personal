using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StarvisDB;

namespace Starvis.Migrations
{
    [DbContext(typeof(Models))]
    [Migration("20170317035205_StarvisEntities")]
    partial class StarvisEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Starvis.ArenaDB", b =>
                {
                    b.Property<int>("ArenaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppList");

                    b.Property<string>("Name");

                    b.Property<string>("TextCommand");

                    b.Property<string>("VoiceCommand");

                    b.HasKey("ArenaID");

                    b.ToTable("ArenaDB");
                });

            modelBuilder.Entity("Starvis.CodeBaseDB", b =>
                {
                    b.Property<int>("CodeBaseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualCommand");

                    b.Property<string>("CommandType");

                    b.Property<string>("TextCommand");

                    b.Property<string>("VoiceCommand");

                    b.HasKey("CodeBaseID");

                    b.ToTable("CodeBaseDB");
                });

            modelBuilder.Entity("Starvis.HotKeyDB", b =>
                {
                    b.Property<int>("HotKeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<string>("TextCommand");

                    b.Property<string>("Value");

                    b.Property<string>("VoiceCommand");

                    b.HasKey("HotKeyID");

                    b.ToTable("HotKeyDB");
                });

            modelBuilder.Entity("Starvis.JIRADB", b =>
                {
                    b.Property<int>("JIRAID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectType");

                    b.Property<string>("TextCommand");

                    b.Property<string>("URL");

                    b.Property<string>("VoiceCommand");

                    b.HasKey("JIRAID");

                    b.ToTable("JIRADB");
                });

            modelBuilder.Entity("Starvis.OutlookDB", b =>
                {
                    b.Property<int>("OutlookID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Subject");

                    b.Property<string>("TextCommand");

                    b.Property<string>("To");

                    b.Property<string>("Type");

                    b.Property<string>("VoiceCommand");

                    b.HasKey("OutlookID");

                    b.ToTable("OutlookDB");
                });

            modelBuilder.Entity("Starvis.ProfileDB", b =>
                {
                    b.Property<int>("ProfileDBID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrightnessValue");

                    b.Property<int>("ContrastValue");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("TextCommand");

                    b.Property<string>("VoiceCommand");

                    b.Property<int>("Volume");

                    b.HasKey("ProfileDBID");

                    b.ToTable("ProfileDB");
                });

            modelBuilder.Entity("Starvis.SettingsDB", b =>
                {
                    b.Property<int>("SettingsID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("SettingsID");

                    b.ToTable("SettingsDB");
                });

            modelBuilder.Entity("Starvis.WebDB", b =>
                {
                    b.Property<int>("WebID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TextCommand");

                    b.Property<string>("URL");

                    b.Property<string>("VoiceCommand");

                    b.HasKey("WebID");

                    b.ToTable("WebDB");
                });
        }
    }
}

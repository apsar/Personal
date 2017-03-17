using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Starvis.Migrations
{
    public partial class StarvisEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArenaDB",
                columns: table => new
                {
                    ArenaID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppList = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TextCommand = table.Column<string>(nullable: true),
                    VoiceCommand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaDB", x => x.ArenaID);
                });

            migrationBuilder.CreateTable(
                name: "CodeBaseDB",
                columns: table => new
                {
                    CodeBaseID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActualCommand = table.Column<string>(nullable: true),
                    CommandType = table.Column<string>(nullable: true),
                    TextCommand = table.Column<string>(nullable: true),
                    VoiceCommand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeBaseDB", x => x.CodeBaseID);
                });

            migrationBuilder.CreateTable(
                name: "HotKeyDB",
                columns: table => new
                {
                    HotKeyID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(nullable: true),
                    TextCommand = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    VoiceCommand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotKeyDB", x => x.HotKeyID);
                });

            migrationBuilder.CreateTable(
                name: "JIRADB",
                columns: table => new
                {
                    JIRAID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectType = table.Column<string>(nullable: true),
                    TextCommand = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    VoiceCommand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JIRADB", x => x.JIRAID);
                });

            migrationBuilder.CreateTable(
                name: "OutlookDB",
                columns: table => new
                {
                    OutlookID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Body = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    TextCommand = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    VoiceCommand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutlookDB", x => x.OutlookID);
                });

            migrationBuilder.CreateTable(
                name: "ProfileDB",
                columns: table => new
                {
                    ProfileDBID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrightnessValue = table.Column<int>(nullable: false),
                    ContrastValue = table.Column<int>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    TextCommand = table.Column<string>(nullable: true),
                    VoiceCommand = table.Column<string>(nullable: true),
                    Volume = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileDB", x => x.ProfileDBID);
                });

            migrationBuilder.CreateTable(
                name: "SettingsDB",
                columns: table => new
                {
                    SettingsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsDB", x => x.SettingsID);
                });

            migrationBuilder.CreateTable(
                name: "WebDB",
                columns: table => new
                {
                    WebID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TextCommand = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    VoiceCommand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebDB", x => x.WebID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArenaDB");

            migrationBuilder.DropTable(
                name: "CodeBaseDB");

            migrationBuilder.DropTable(
                name: "HotKeyDB");

            migrationBuilder.DropTable(
                name: "JIRADB");

            migrationBuilder.DropTable(
                name: "OutlookDB");

            migrationBuilder.DropTable(
                name: "ProfileDB");

            migrationBuilder.DropTable(
                name: "SettingsDB");

            migrationBuilder.DropTable(
                name: "WebDB");
        }
    }
}

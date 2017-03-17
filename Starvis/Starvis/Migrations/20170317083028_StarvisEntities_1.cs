using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Starvis.Migrations
{
    public partial class StarvisEntities_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "OutlookDB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchKey",
                table: "OutlookDB",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnReadMailCount",
                table: "OutlookDB",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "OutlookDB");

            migrationBuilder.DropColumn(
                name: "SearchKey",
                table: "OutlookDB");

            migrationBuilder.DropColumn(
                name: "UnReadMailCount",
                table: "OutlookDB");
        }
    }
}

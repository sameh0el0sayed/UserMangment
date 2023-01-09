using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserMangment.Migrations
{
    public partial class EditUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Security",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Security",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "Security",
                table: "User",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Security",
                table: "User");

           
        }
    }
}

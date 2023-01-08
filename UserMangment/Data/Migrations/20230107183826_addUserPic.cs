using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserMangment.Data.Migrations
{
    public partial class addUserPic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "Security",
                table: "User",
                type: "varbinary(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Security",
                table: "User");
        }
    }
}

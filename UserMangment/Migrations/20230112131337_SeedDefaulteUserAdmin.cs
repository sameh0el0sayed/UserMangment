using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using UserMangment.Helper;
using UserMangment.Models;

#nullable disable

namespace UserMangment.Migrations
{
    public partial class SeedDefaulteUserAdmin : Migration
    {
        const string userID = "f6340718-6003-4b99-8e83-fb8ebeaa7ddf";
        const string userRoleID = "dabb3c64-0ae5-4df8-8d44-c3f97fcaa2df";
        const string AdminUserID = "c19f60f3-8ae3-4976-a514-13a7fa98ac9a";
        const string AdminUserRoleID = "865c4814-e4a2-4c6b-901c-e957010d1fbb";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            //normal user

            migrationBuilder.InsertData(
                table: "User",
                schema: "Security",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp" , "AccessFailedCount", "TwoFactorEnabled", "LockoutEnabled" , "Discriminator", "PhoneNumberConfirmed" },
                values: new object[] { userID, "user", "user".ToUpper(), "user@email.com", "user@email.com".ToUpper(),true,
                hasher.HashPassword(null, "userpassword"),string.Empty,0,false,false,nameof(ApplicationUser),false
                });

            migrationBuilder.InsertData(
              table: "Role",
              schema: "Security",
              columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
              values: new object[] { userRoleID, ApplicationRoleName.User, ApplicationRoleName.User.ToUpper(), userRoleID });

            migrationBuilder.InsertData(
              table: "UserRole",
              schema: "Security",
              columns: new[] { "UserId", "RoleId" },
              values: new object[] { userID, userRoleID });


            //admin user

            migrationBuilder.InsertData(
                table: "User",
                schema: "Security",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp","AccessFailedCount", "TwoFactorEnabled", "LockoutEnabled" ,"Discriminator", "PhoneNumberConfirmed" },
                values: new object[] { AdminUserID, "admin", "admin".ToUpper(), "admin@email.com", "admin@email.com".ToUpper(),true,
                hasher.HashPassword(null, "adminpassword"),string.Empty,0,false,false,nameof(ApplicationUser),false
                });

            migrationBuilder.InsertData(
              table: "Role",
              schema: "Security",
              columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
              values: new object[] { AdminUserRoleID, ApplicationRoleName.Admin, ApplicationRoleName.Admin.ToUpper(), AdminUserRoleID });

            migrationBuilder.InsertData(
              table: "UserRole",
              schema: "Security",
              columns: new[] { "UserId", "RoleId" },
              values: new object[] { AdminUserID, AdminUserRoleID });

            migrationBuilder.InsertData(
            table: "UserRole",
            schema: "Security",
            columns: new[] { "UserId", "RoleId" },
            values: new object[] { AdminUserID, userRoleID });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "User",
            schema: "Security",
            keyColumns: new[] { "Id" },
            keyValues: new object[] { userID
            });

            migrationBuilder.DeleteData(
              table: "Role",
              schema: "Security",
              keyColumns: new[] { "Id" },
              keyValues: new object[] { userRoleID });

            migrationBuilder.DeleteData(
              table: "UserRole",
              schema: "Security",
              keyColumns: new[] { "UserId", "RoleId" },
              keyValues: new object[] { userID, userRoleID });


            migrationBuilder.DeleteData(
                table: "User",
                schema: "Security",
                keyColumns: new[] { "Id" },
                keyValues: new object[] { userID });

            migrationBuilder.DeleteData(
              table: "Role",
              schema: "Security",
              keyColumns: new[] { "Id" },
              keyValues: new object[] { AdminUserRoleID });

            migrationBuilder.DeleteData(
              table: "UserRole",
              schema: "Security",
              keyColumns: new[] { "UserId", "RoleId" },
              keyValues: new object[] { AdminUserID, AdminUserRoleID });
        }
    }
}

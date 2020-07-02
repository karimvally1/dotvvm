using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AspNetUserId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "AspNetUserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cc9bcbd-ace6-4cdc-91e5-34f1bad14ca1", "9255e927-ad96-47b5-8418-aa4dae1bd708", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bc62cdff-77ca-4473-a467-210eb36fdd5d", 0, "714dd158-2ce7-4e60-839f-6fa1cb0d19ba", "admin@dotvvm.com", true, false, null, "ADMIN@DOTVVM.COM", "ADMIN", "AQAAAAEAACcQAAAAEEOAoqauliOjPMo7OCJcYVw6DunPi06nKZjps9DuaVQOg/l7TDhQkbDZKpGgjIDuSg==", null, false, "05ee91a2-0f73-4a92-be2a-f95b59a48e74", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "bc62cdff-77ca-4473-a467-210eb36fdd5d", "4cc9bcbd-ace6-4cdc-91e5-34f1bad14ca1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "AspNetUserId", "FirstName", "LastName" },
                values: new object[] { "bc62cdff-77ca-4473-a467-210eb36fdd5d", "Karim", "Vally" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUserId",
                table: "Users",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "bc62cdff-77ca-4473-a467-210eb36fdd5d", "4cc9bcbd-ace6-4cdc-91e5-34f1bad14ca1" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "AspNetUserId",
                keyValue: "bc62cdff-77ca-4473-a467-210eb36fdd5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc9bcbd-ace6-4cdc-91e5-34f1bad14ca1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc62cdff-77ca-4473-a467-210eb36fdd5d");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AspNetUserId",
                table: "Users",
                column: "AspNetUserId",
                unique: true,
                filter: "[AspNetUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_AspNetUserId",
                table: "Users",
                column: "AspNetUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

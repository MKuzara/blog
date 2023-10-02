using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.API.Migrations
{
    /// <inheritdoc />
    public partial class UserEmailFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6682b6cc-9ea9-4ff3-92dc-cbd306a31cd4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7adb9c26-28d4-4f44-bd87-9c555d875cef", "AQAAAAIAAYagAAAAELb5Bb6+K5aYBkOqhBMDaiP2hq1tPbD0i/+eFMHOtoA5krmqGAikYx4f9ub+vBbSYA==", "527e2706-12c0-4d0f-9d11-bbcd76a8c387" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b73ee27e-4084-45ff-b7dd-5a821adef831",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "275616cb-9f0e-438d-9c09-7af52c253dff", "AQAAAAIAAYagAAAAEE0+E/KzFqVw68oulqgvU4S4++EfPV30DqMA5ZZZJicrvEm5geiawfIDwhhjqba1/g==", "847663b2-243a-4a8d-93f9-75c5212d6bfe" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("2a9247f1-6aee-4c2f-9795-a1d98d8d3937"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 18, 34, 45, 934, DateTimeKind.Utc).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("453fae99-af87-40e5-a005-eace9e3862c1"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 18, 34, 45, 934, DateTimeKind.Utc).AddTicks(2240));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("4afaa9a9-7488-4168-9be2-56138e6a2882"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 18, 34, 45, 934, DateTimeKind.Utc).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("ad417376-e1e8-4b18-bfb5-c00e155e9926"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 18, 34, 45, 934, DateTimeKind.Utc).AddTicks(2247));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6682b6cc-9ea9-4ff3-92dc-cbd306a31cd4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "916a5753-41fa-4694-ac6c-ff615a8c645d", "AQAAAAIAAYagAAAAEAum55nOPmPp5IF2gD7+kgeQKGllTSVymTRcxOfwtsuQdbOBdHadhr1bly4FqzUSvw==", "3045d34f-c29e-4461-a895-9a4d99fd60b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b73ee27e-4084-45ff-b7dd-5a821adef831",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29a16a19-77d0-4200-ba56-358e24a27cb3", "AQAAAAIAAYagAAAAEO7TiUEiDEIwcD7lX7VrtsC+5meTSMmAhvEQcLD6yahx9/zGa4hxVfFOpqWxLd/AAQ==", "d3e4e862-8b63-4b54-943e-95a7408792c5" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("2a9247f1-6aee-4c2f-9795-a1d98d8d3937"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 11, 58, 36, 852, DateTimeKind.Utc).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("453fae99-af87-40e5-a005-eace9e3862c1"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 11, 58, 36, 852, DateTimeKind.Utc).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("4afaa9a9-7488-4168-9be2-56138e6a2882"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 11, 58, 36, 852, DateTimeKind.Utc).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: new Guid("ad417376-e1e8-4b18-bfb5-c00e155e9926"),
                column: "CreatedDate",
                value: new DateTime(2023, 10, 2, 11, 58, 36, 852, DateTimeKind.Utc).AddTicks(796));
        }
    }
}

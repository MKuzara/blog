using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.API.Migrations
{
    /// <inheritdoc />
    public partial class BaseModelsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6682b6cc-9ea9-4ff3-92dc-cbd306a31cd4"), 0, "08d8fc52-6baa-4534-8618-fff24a994d73", "user2@example.com", false, false, null, null, null, null, null, false, "5952bd59-30a5-4f6e-b161-2f9814fc3ae8", false, "example_user_2" },
                    { new Guid("b73ee27e-4084-45ff-b7dd-5a821adef831"), 0, "ccd0bd9e-860c-4a88-bcbc-b7ae1523a81e", "user1@example.com", false, false, null, null, null, null, null, false, "68511df4-5a88-48b6-9b96-013dd3cca6f6", false, "example_user_1" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Content", "CreatedDate", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("2a9247f1-6aee-4c2f-9795-a1d98d8d3937"), "\r\n                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. \r\n                        Fusce iaculis vehicula neque ut fermentum. Ut urna justo, \r\n                        porttitor sit amet diam at, dictum vulputate elit.", new DateTime(2023, 9, 30, 20, 39, 31, 855, DateTimeKind.Local).AddTicks(4767), "Blog Post #1", null, new Guid("b73ee27e-4084-45ff-b7dd-5a821adef831") },
                    { new Guid("453fae99-af87-40e5-a005-eace9e3862c1"), "\r\n                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. \r\n                        Nunc sed nisl diam. Pellentesque habitant morbi tristique \r\n                        senectus et netus et.", new DateTime(2023, 9, 30, 20, 39, 31, 855, DateTimeKind.Local).AddTicks(4806), "Blog Post #2", null, new Guid("6682b6cc-9ea9-4ff3-92dc-cbd306a31cd4") },
                    { new Guid("4afaa9a9-7488-4168-9be2-56138e6a2882"), "\r\n                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. \r\n                        Duis cursus tincidunt feugiat. Nullam molestie dui id velit \r\n                        vehicula porttitor. Vestibulum.", new DateTime(2023, 9, 30, 20, 39, 31, 855, DateTimeKind.Local).AddTicks(4815), "Blog Post #1", null, new Guid("b73ee27e-4084-45ff-b7dd-5a821adef831") },
                    { new Guid("ad417376-e1e8-4b18-bfb5-c00e155e9926"), "\r\n                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. \r\n                        Cras eget finibus nibh. Suspendisse sem ante, ultrices eu \r\n                        ultricies non, facilisis.", new DateTime(2023, 9, 30, 20, 39, 31, 855, DateTimeKind.Local).AddTicks(4810), "Blog Post #1", null, new Guid("b73ee27e-4084-45ff-b7dd-5a821adef831") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_UserId",
                table: "BlogPosts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpertsDirectory.API.Migrations
{
    public partial class GenerateContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberFriend",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    FriendId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberFriend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberFriend_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberHeader",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberHeader_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "Name", "Website" },
                values: new object[] { 1L, "waqas.haneef1@gmail.com", "Waqas Haneef", "www.waqashaneef.com" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "Name", "Website" },
                values: new object[] { 2L, "chadeelahmed@gmail.com", "Adeel Ahmed", "www.adeelahmed.com" });

            migrationBuilder.InsertData(
                table: "MemberFriend",
                columns: new[] { "Id", "FriendId", "MemberId" },
                values: new object[,]
                {
                    { 1L, 2L, 1L },
                    { 2L, 1L, 2L }
                });

            migrationBuilder.InsertData(
                table: "MemberHeader",
                columns: new[] { "Id", "MemberId", "Text" },
                values: new object[,]
                {
                    { 1L, 1L, "Web Programing" },
                    { 2L, 1L, "Software Solutions" },
                    { 3L, 1L, "Cloud Soultions" },
                    { 4L, 2L, "Back-end Programing" },
                    { 5L, 2L, "Software Solutions" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberFriend_MemberId",
                table: "MemberFriend",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberHeader_MemberId",
                table: "MemberHeader",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberFriend");

            migrationBuilder.DropTable(
                name: "MemberHeader");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}

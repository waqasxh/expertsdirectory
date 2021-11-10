using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpertsDirectory.API.Migrations
{
    public partial class ExpertDirectoryAPIModelsExpertDirectoryContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Email", "Name", "Website" },
                values: new object[] { 1L, "waqas.haneef1@gmail.com", "Waqas haneef", "www.waqashaneef.com" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Email", "Name", "Website" },
                values: new object[] { 2L, "waqas.haneef1@hotmail.com", "Waqas haneef", "www.waqashaneef1.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2L);
        }
    }
}

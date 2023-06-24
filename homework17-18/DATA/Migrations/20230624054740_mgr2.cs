using Microsoft.EntityFrameworkCore.Migrations;

namespace DATA.Migrations
{
    public partial class mgr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Respodents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$10$uwMr0KMtj6sfcvVTtfmeE.zZbdx.IXPF34kPAcfl7ztuqzCzmnH7W", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Respodents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$10$dkQQtyr3d.0kOEb5.9kl2uGHvGpOfrxOwJtHeqaSwNgmamptVZnSe", "Adming" });
        }
    }
}

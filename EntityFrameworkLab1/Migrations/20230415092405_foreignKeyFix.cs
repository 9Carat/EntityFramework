using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkLab1.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vacations_FK_EmpId",
                table: "Vacations");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_FK_EmpId",
                table: "Vacations",
                column: "FK_EmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vacations_FK_EmpId",
                table: "Vacations");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_FK_EmpId",
                table: "Vacations",
                column: "FK_EmpId",
                unique: true);
        }
    }
}

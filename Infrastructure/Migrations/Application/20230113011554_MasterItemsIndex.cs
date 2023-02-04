using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Application
{
    /// <inheritdoc />
    public partial class MasterItemsIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MasterName",
                schema: "NewWorld",
                table: "MasterItemDefinitions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterItemDefinitions_GearScoreOverride",
                schema: "NewWorld",
                table: "MasterItemDefinitions",
                column: "GearScoreOverride");

            migrationBuilder.CreateIndex(
                name: "IX_MasterItemDefinitions_ItemID",
                schema: "NewWorld",
                table: "MasterItemDefinitions",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterItemDefinitions_MasterName",
                schema: "NewWorld",
                table: "MasterItemDefinitions",
                column: "MasterName");

            migrationBuilder.CreateIndex(
                name: "IX_MasterItemDefinitions_Tier",
                schema: "NewWorld",
                table: "MasterItemDefinitions",
                column: "Tier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MasterItemDefinitions_GearScoreOverride",
                schema: "NewWorld",
                table: "MasterItemDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_MasterItemDefinitions_ItemID",
                schema: "NewWorld",
                table: "MasterItemDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_MasterItemDefinitions_MasterName",
                schema: "NewWorld",
                table: "MasterItemDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_MasterItemDefinitions_Tier",
                schema: "NewWorld",
                table: "MasterItemDefinitions");

            migrationBuilder.AlterColumn<string>(
                name: "MasterName",
                schema: "NewWorld",
                table: "MasterItemDefinitions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

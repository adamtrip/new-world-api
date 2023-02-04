using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Application
{
    /// <inheritdoc />
    public partial class StaggerDamageNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "WarHammerAbilityTable",
                newName: "staggerdamage");

            migrationBuilder.RenameColumn(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "RuneAbilityTable",
                newName: "staggerdamage");

            migrationBuilder.RenameColumn(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "MusketAbilityTable",
                newName: "staggerdamage");

            migrationBuilder.RenameColumn(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "HatchetAbilityTable",
                newName: "staggerdamage");

            migrationBuilder.RenameColumn(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "GlobalAbilityTable",
                newName: "staggerdamage");

            migrationBuilder.RenameColumn(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "FireMagicAbilityTable",
                newName: "staggerdamage");

            migrationBuilder.RenameColumn(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "BowAbilityTable",
                newName: "staggerdamage");

            migrationBuilder.RenameColumn(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "BlunderbussAbilityTable",
                newName: "staggerdamage");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "WarHammerAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "VoidGauntletAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "SwordAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "SpearAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "RuneAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "RapierAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "MusketAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "LifeMagicAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "IceMagicAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "HatchetAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "GreatswordAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "GreatAxeAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "GlobalAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "FireMagicAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "BowAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "BlunderbussAbilityTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "WarHammerAbilityTable",
                newName: "StaggerDamage");

            migrationBuilder.RenameColumn(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "RuneAbilityTable",
                newName: "StaggerDamage");

            migrationBuilder.RenameColumn(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "MusketAbilityTable",
                newName: "StaggerDamage");

            migrationBuilder.RenameColumn(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "HatchetAbilityTable",
                newName: "StaggerDamage");

            migrationBuilder.RenameColumn(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "GlobalAbilityTable",
                newName: "StaggerDamage");

            migrationBuilder.RenameColumn(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "FireMagicAbilityTable",
                newName: "StaggerDamage");

            migrationBuilder.RenameColumn(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "BowAbilityTable",
                newName: "StaggerDamage");

            migrationBuilder.RenameColumn(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "BlunderbussAbilityTable",
                newName: "StaggerDamage");

            migrationBuilder.AlterColumn<string>(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "WarHammerAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "VoidGauntletAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "SwordAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "SpearAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "RuneAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "RapierAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "MusketAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "LifeMagicAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "IceMagicAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "HatchetAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "GreatswordAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "staggerdamage",
                schema: "NewWorld",
                table: "GreatAxeAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "GlobalAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "FireMagicAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "BowAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaggerDamage",
                schema: "NewWorld",
                table: "BlunderbussAbilityTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

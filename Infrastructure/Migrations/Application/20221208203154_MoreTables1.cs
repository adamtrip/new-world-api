using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Application
{
    /// <inheritdoc />
    public partial class MoreTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerkBucketPerks_PerkBuckets_PerkBucketsId1",
                schema: "NewWorld",
                table: "PerkBucketPerks");

            migrationBuilder.DropIndex(
                name: "IX_PerkBucketPerks_PerkBucketsId1",
                schema: "NewWorld",
                table: "PerkBucketPerks");

            migrationBuilder.DropColumn(
                name: "PerkBucketPerkId",
                schema: "NewWorld",
                table: "PerkBucketPerks");

            migrationBuilder.RenameColumn(
                name: "PerkBucketsId1",
                schema: "NewWorld",
                table: "PerkBucketPerks",
                newName: "PerkBucketId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PerkBucketsId",
                schema: "NewWorld",
                table: "PerkBucketPerks",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PerkBucketPerks_PerkBucketsId",
                schema: "NewWorld",
                table: "PerkBucketPerks",
                column: "PerkBucketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerkBucketPerks_PerkBuckets_PerkBucketsId",
                schema: "NewWorld",
                table: "PerkBucketPerks",
                column: "PerkBucketsId",
                principalSchema: "NewWorld",
                principalTable: "PerkBuckets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerkBucketPerks_PerkBuckets_PerkBucketsId",
                schema: "NewWorld",
                table: "PerkBucketPerks");

            migrationBuilder.DropIndex(
                name: "IX_PerkBucketPerks_PerkBucketsId",
                schema: "NewWorld",
                table: "PerkBucketPerks");

            migrationBuilder.RenameColumn(
                name: "PerkBucketId",
                schema: "NewWorld",
                table: "PerkBucketPerks",
                newName: "PerkBucketsId1");

            migrationBuilder.AlterColumn<string>(
                name: "PerkBucketsId",
                schema: "NewWorld",
                table: "PerkBucketPerks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "PerkBucketPerkId",
                schema: "NewWorld",
                table: "PerkBucketPerks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PerkBucketPerks_PerkBucketsId1",
                schema: "NewWorld",
                table: "PerkBucketPerks",
                column: "PerkBucketsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PerkBucketPerks_PerkBuckets_PerkBucketsId1",
                schema: "NewWorld",
                table: "PerkBucketPerks",
                column: "PerkBucketsId1",
                principalSchema: "NewWorld",
                principalTable: "PerkBuckets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

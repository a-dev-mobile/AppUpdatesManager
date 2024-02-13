using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppUpdatesManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUpdates",
                columns: table => new
                {
                    ApplicationUpdateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PackageName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUpdates", x => x.ApplicationUpdateId);
                });

            migrationBuilder.CreateTable(
                name: "DownloadDetails",
                columns: table => new
                {
                    DownloadDetailId = table.Column<int>(type: "integer", nullable: false),
                    DownloadUrl = table.Column<string>(type: "text", nullable: false),
                    ApplicationUpdateEntityApplicationUpdateId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadDetails", x => x.DownloadDetailId);
                    table.ForeignKey(
                        name: "FK_DownloadDetails_ApplicationUpdates_ApplicationUpdateEntityA~",
                        column: x => x.ApplicationUpdateEntityApplicationUpdateId,
                        principalTable: "ApplicationUpdates",
                        principalColumn: "ApplicationUpdateId");
                });

            migrationBuilder.CreateTable(
                name: "SoftwareVersions",
                columns: table => new
                {
                    SoftwareVersionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Checksum = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    SizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    DownloadDetailId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareVersions", x => x.SoftwareVersionId);
                    table.ForeignKey(
                        name: "FK_SoftwareVersions_DownloadDetails_DownloadDetailId",
                        column: x => x.DownloadDetailId,
                        principalTable: "DownloadDetails",
                        principalColumn: "DownloadDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpdateRequirements",
                columns: table => new
                {
                    UpdateRequirementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateRequirements", x => x.UpdateRequirementId);
                });

            migrationBuilder.CreateTable(
                name: "UpdateStrategies",
                columns: table => new
                {
                    UpdateStrategyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MinimumCode = table.Column<int>(type: "integer", nullable: false),
                    UpdateRequirementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateStrategies", x => x.UpdateStrategyId);
                    table.ForeignKey(
                        name: "FK_UpdateStrategies_UpdateRequirements_UpdateRequirementId",
                        column: x => x.UpdateRequirementId,
                        principalTable: "UpdateRequirements",
                        principalColumn: "UpdateRequirementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DownloadDetails_ApplicationUpdateEntityApplicationUpdateId",
                table: "DownloadDetails",
                column: "ApplicationUpdateEntityApplicationUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftwareVersions_DownloadDetailId",
                table: "SoftwareVersions",
                column: "DownloadDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdateStrategies_UpdateRequirementId",
                table: "UpdateStrategies",
                column: "UpdateRequirementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadDetails_SoftwareVersions_DownloadDetailId",
                table: "DownloadDetails",
                column: "DownloadDetailId",
                principalTable: "SoftwareVersions",
                principalColumn: "SoftwareVersionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadDetails_UpdateRequirements_DownloadDetailId",
                table: "DownloadDetails",
                column: "DownloadDetailId",
                principalTable: "UpdateRequirements",
                principalColumn: "UpdateRequirementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpdateRequirements_UpdateStrategies_UpdateRequirementId",
                table: "UpdateRequirements",
                column: "UpdateRequirementId",
                principalTable: "UpdateStrategies",
                principalColumn: "UpdateStrategyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DownloadDetails_ApplicationUpdates_ApplicationUpdateEntityA~",
                table: "DownloadDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DownloadDetails_SoftwareVersions_DownloadDetailId",
                table: "DownloadDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UpdateStrategies_UpdateRequirements_UpdateRequirementId",
                table: "UpdateStrategies");

            migrationBuilder.DropTable(
                name: "ApplicationUpdates");

            migrationBuilder.DropTable(
                name: "SoftwareVersions");

            migrationBuilder.DropTable(
                name: "DownloadDetails");

            migrationBuilder.DropTable(
                name: "UpdateRequirements");

            migrationBuilder.DropTable(
                name: "UpdateStrategies");
        }
    }
}

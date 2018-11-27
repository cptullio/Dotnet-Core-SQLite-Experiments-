using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sonda.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    UrlTest = table.Column<string>(nullable: true),
                    ExecutionBegin = table.Column<DateTime>(nullable: true),
                    ExecutionEnd = table.Column<DateTime>(nullable: true),
                    IntervalExecution = table.Column<int>(nullable: false),
                    IntervalDataSourceItem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Command",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CommandType = table.Column<byte>(nullable: false),
                    Target = table.Column<string>(nullable: true),
                    SearchTargetType = table.Column<byte>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    CanBeIgnored = table.Column<bool>(nullable: true),
                    IsFromDatasource = table.Column<bool>(nullable: true),
                    IsFromService = table.Column<bool>(nullable: true),
                    UrlService = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Command", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Command_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSource_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentDataSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Chave = table.Column<string>(nullable: true),
                    Alvo = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true),
                    DatasourceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentDataSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentDataSource_DataSource_DatasourceId",
                        column: x => x.DatasourceId,
                        principalTable: "DataSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Command_TestId",
                table: "Command",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentDataSource_DatasourceId",
                table: "ContentDataSource",
                column: "DatasourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSource_TestId",
                table: "DataSource",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Command");

            migrationBuilder.DropTable(
                name: "ContentDataSource");

            migrationBuilder.DropTable(
                name: "DataSource");

            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataType",
                columns: table => new
                {
                    DataTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataType", x => x.DataTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ReportOperations",
                columns: table => new
                {
                    ReportOperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportOperationName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportOperations", x => x.ReportOperationId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "ReportTrackings",
                columns: table => new
                {
                    ReportTrackingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    ReportOperationId = table.Column<int>(type: "int", nullable: false),
                    DateTracking = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportTrackings", x => x.ReportTrackingId);
                    table.ForeignKey(
                        name: "FK_ReportTrackings_ReportOperations_ReportOperationId",
                        column: x => x.ReportOperationId,
                        principalTable: "ReportOperations",
                        principalColumn: "ReportOperationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportTrackings_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariableFields",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableFields", x => new { x.ReportId, x.Label });
                    table.ForeignKey(
                        name: "FK_VariableFields_DataType_DataTypeId",
                        column: x => x.DataTypeId,
                        principalTable: "DataType",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariableFields_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DataType",
                columns: new[] { "DataTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Entero" },
                    { 2, "String" },
                    { 3, "Date" },
                    { 4, "Bool" },
                    { 5, "Decimal" }
                });

            migrationBuilder.InsertData(
                table: "ReportOperations",
                columns: new[] { "ReportOperationId", "ReportOperationName" },
                values: new object[,]
                {
                    { 1, "Creacion" },
                    { 2, "Aprobacion" },
                    { 3, "Rechazo" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Amount", "Description", "EmployeeId" },
                values: new object[,]
                {
                    { 1, 7500.0, "Bolsa de cemento", 1 },
                    { 2, 15000.0, "Placa Mdf", 2 },
                    { 3, 3500.0, "Bola de cal", 2 }
                });

            migrationBuilder.InsertData(
                table: "ReportTrackings",
                columns: new[] { "ReportTrackingId", "DateTracking", "EmployeeId", "ReportId", "ReportOperationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 5, 14, 30, 20, 0, DateTimeKind.Unspecified), 1, 1, 1 },
                    { 2, new DateTime(2023, 9, 7, 9, 20, 9, 0, DateTimeKind.Unspecified), 2, 2, 1 },
                    { 3, new DateTime(2023, 9, 15, 16, 15, 43, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 4, new DateTime(2023, 9, 17, 18, 33, 1, 0, DateTimeKind.Unspecified), 2, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "VariableFields",
                columns: new[] { "Label", "ReportId", "DataTypeId", "Value" },
                values: new object[,]
                {
                    { "Proveedor", 1, 2, "Constructura X SRL" },
                    { "Tel. Proveedor", 1, 1, "42561873" },
                    { "Alto", 2, 1, "180" },
                    { "Ancho[mm]", 2, 1, "270" },
                    { "Peso[kg]", 2, 5, "58.8" },
                    { "Proveedor", 3, 2, "Constructura X SRL" },
                    { "Tel. Proveedor", 3, 1, "42561873" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportTrackings_ReportId",
                table: "ReportTrackings",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportTrackings_ReportOperationId",
                table: "ReportTrackings",
                column: "ReportOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableFields_DataTypeId",
                table: "VariableFields",
                column: "DataTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportTrackings");

            migrationBuilder.DropTable(
                name: "VariableFields");

            migrationBuilder.DropTable(
                name: "ReportOperations");

            migrationBuilder.DropTable(
                name: "DataType");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}

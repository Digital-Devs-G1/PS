using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                name: "DepartmentTemplates",
                columns: table => new
                {
                    DepartmentTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentTemplateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTemplates", x => x.DepartmentTemplateId);
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
                name: "FieldTemplates",
                columns: table => new
                {
                    DepartmentTemplateId = table.Column<int>(type: "int", nullable: false),
                    OrdinalNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTemplates", x => new { x.DepartmentTemplateId, x.OrdinalNumber });
                    table.ForeignKey(
                        name: "FK_FieldTemplates_DataType_DataTypeId",
                        column: x => x.DataTypeId,
                        principalTable: "DataType",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportTrackings",
                columns: table => new
                {
                    ReportTrackingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    ReportOperationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TrackingDate = table.Column<DateTime>(type: "datetime", nullable: false)
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
                    OrdinalNumberId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableFields", x => new { x.ReportId, x.OrdinalNumberId });
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
                table: "DepartmentTemplates",
                columns: new[] { "DepartmentTemplateId", "DepartmentId", "DepartmentTemplateName" },
                values: new object[,]
                {
                    { 1, 1, "Auto Propio" },
                    { 2, 1, "Servicio Viaje" },
                    { 3, 1, "Viaticos" },
                    { 4, 2, "Gastos varios" },
                    { 5, 2, "Materia prima" },
                    { 6, 3, "Materiales de Construccion" },
                    { 7, 3, "Placas de Carpinteria" }
                });

            migrationBuilder.InsertData(
                table: "ReportOperations",
                columns: new[] { "ReportOperationId", "ReportOperationName" },
                values: new object[,]
                {
                    { 1, "Creacion" },
                    { 2, "Revision" },
                    { 3, "Aprobacion" },
                    { 4, "Rechazo" }
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
                table: "FieldTemplates",
                columns: new[] { "DepartmentTemplateId", "OrdinalNumber", "DataTypeId", "Enabled", "Name" },
                values: new object[,]
                {
                    { 1, 1, 2, true, "Destino" },
                    { 1, 2, 5, true, "Km" },
                    { 1, 3, 4, true, "HuboPeajes" },
                    { 1, 4, 5, true, "Monto Peajes" },
                    { 2, 1, 2, true, "Destino" },
                    { 2, 2, 2, true, "Nombre Servicio" },
                    { 2, 3, 2, true, "Comprobante" },
                    { 3, 1, 2, true, "Viatico" },
                    { 3, 2, 2, true, "Motivo" },
                    { 3, 3, 2, true, "Comprobante" },
                    { 4, 1, 2, true, "Proveedor" },
                    { 4, 2, 1, true, "Contacto" },
                    { 4, 3, 2, true, "Nombre Material" },
                    { 4, 4, 5, true, "Peso [Kg]" },
                    { 4, 5, 1, true, "Ancho [mm]" },
                    { 4, 6, 1, true, "Alto [mm]" },
                    { 5, 1, 2, true, "Viatico" },
                    { 5, 2, 2, true, "Motivo" },
                    { 5, 3, 2, true, "Comprobante" },
                    { 6, 1, 2, true, "Proveedor" },
                    { 6, 2, 1, true, "Tel. Proveedor" },
                    { 7, 1, 1, true, "Ancho [mm]" },
                    { 7, 2, 1, true, "Alto [mm]" },
                    { 7, 3, 5, true, "Peso [Kg]" }
                });

            migrationBuilder.InsertData(
                table: "ReportTrackings",
                columns: new[] { "ReportTrackingId", "EmployeeId", "ReportId", "ReportOperationId", "TrackingDate" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, new DateTime(2023, 9, 5, 14, 30, 20, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, 1, new DateTime(2023, 9, 7, 9, 20, 9, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 2, 2, new DateTime(2023, 9, 15, 16, 15, 43, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 3, 1, new DateTime(2023, 9, 17, 18, 33, 1, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "VariableFields",
                columns: new[] { "OrdinalNumberId", "ReportId", "DataTypeId", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, 2, "Proveedor", "Constructura X SRL" },
                    { 2, 1, 1, "Tel. Proveedor", "42561873" },
                    { 1, 2, 1, "Ancho [mm]", "270" },
                    { 2, 2, 1, "Alto [mm]", "180" },
                    { 3, 2, 5, "Peso [kg]", "58.8" },
                    { 1, 3, 2, "Proveedor", "Constructura X SRL" },
                    { 2, 3, 1, "Tel. Proveedor", "42561873" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldTemplates_DataTypeId",
                table: "FieldTemplates",
                column: "DataTypeId");

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
                name: "DepartmentTemplates");

            migrationBuilder.DropTable(
                name: "FieldTemplates");

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

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
                    FieldTemplateId = table.Column<int>(type: "int", nullable: false),
                    FieldNameId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTemplates", x => new { x.FieldTemplateId, x.FieldNameId });
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
                    NameId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableFields", x => new { x.ReportId, x.NameId });
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
                columns: new[] { "FieldNameId", "FieldTemplateId", "DataTypeId", "Enabled" },
                values: new object[,]
                {
                    { "Destino", 1, 2, true },
                    { "Km", 2, 5, true },
                    { "HuboPeajes", 3, 4, true },
                    { "Monto Peajes", 4, 5, true },
                    { "Destino", 5, 2, true },
                    { "Nombre Servicio", 6, 2, true },
                    { "Comprobante", 7, 2, true },
                    { "Viatico", 8, 2, true },
                    { "Motivo", 9, 2, true },
                    { "Comprobante", 10, 2, true },
                    { "Proveedor", 11, 2, true },
                    { "Contacto", 12, 1, true },
                    { "Nombre Material", 13, 2, true },
                    { "Peso [Kg]", 14, 5, true },
                    { "Ancho [mm]", 15, 1, true },
                    { "Alto [mm]", 16, 1, true },
                    { "Viatico", 17, 2, true },
                    { "Motivo", 18, 2, true },
                    { "Comprobante", 19, 2, true },
                    { "Proveedor", 20, 2, true },
                    { "Tel. Proveedor", 21, 1, true },
                    { "Ancho [mm]", 22, 1, true },
                    { "Alto [mm]", 23, 1, true },
                    { "Peso [Kg]", 24, 5, true }
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
                columns: new[] { "NameId", "ReportId", "DataTypeId", "Value" },
                values: new object[,]
                {
                    { "Proveedor", 1, 2, "Constructura X SRL" },
                    { "Tel. Proveedor", 1, 1, "42561873" },
                    { "Alto [mm]", 2, 1, "180" },
                    { "Ancho [mm]", 2, 1, "270" },
                    { "Peso [kg]", 2, 5, "58.8" },
                    { "Proveedor", 2, 2, "Constructura X SRL" },
                    { "Tel. Proveedor", 2, 1, "42561873" }
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

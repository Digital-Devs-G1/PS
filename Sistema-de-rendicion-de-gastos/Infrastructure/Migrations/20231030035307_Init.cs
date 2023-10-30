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
                    Amount = table.Column<double>(type: "float", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproverId = table.Column<int>(type: "int", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTemplates", x => new { x.DepartmentTemplateId, x.Name });
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
                    ReportId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "ReportId");
                });

            migrationBuilder.CreateTable(
                name: "VariableFields",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableFields", x => new { x.ReportId, x.Name });
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
                columns: new[] { "ReportId", "Amount", "ApproverId", "Description", "EmployeeId", "date" },
                values: new object[,]
                {
                    { 1, 7500.0, 1, "Bolsa de cemento", 1, new DateTime(2023, 10, 30, 0, 53, 7, 652, DateTimeKind.Local).AddTicks(9761) },
                    { 2, 15000.0, 1, "Placa Mdf", 2, new DateTime(2023, 10, 30, 0, 53, 7, 652, DateTimeKind.Local).AddTicks(9774) },
                    { 3, 3500.0, 1, "Bola de cal", 2, new DateTime(2023, 10, 30, 0, 53, 7, 652, DateTimeKind.Local).AddTicks(9775) }
                });

            migrationBuilder.InsertData(
                table: "FieldTemplates",
                columns: new[] { "DepartmentTemplateId", "Name", "DataTypeId", "Enabled" },
                values: new object[,]
                {
                    { 1, "Destino", 2, true },
                    { 1, "HuboPeajes", 4, true },
                    { 1, "Km", 5, true },
                    { 1, "Monto Peajes", 5, true },
                    { 2, "Comprobante", 2, true },
                    { 2, "Destino", 2, true },
                    { 2, "Nombre Servicio", 2, true },
                    { 3, "Comprobante", 2, true },
                    { 3, "Motivo", 2, true },
                    { 3, "Viatico", 2, true },
                    { 4, "Alto [mm]", 1, true },
                    { 4, "Ancho [mm]", 1, true },
                    { 4, "Contacto", 1, true },
                    { 4, "Nombre Material", 2, true },
                    { 4, "Peso [Kg]", 5, true },
                    { 4, "Proveedor", 2, true },
                    { 5, "Comprobante", 2, true },
                    { 5, "Motivo", 2, true },
                    { 5, "Viatico", 2, true },
                    { 6, "Proveedor", 2, true },
                    { 6, "Tel. Proveedor", 1, true },
                    { 7, "Alto [mm]", 1, true },
                    { 7, "Ancho [mm]", 1, true },
                    { 7, "Peso [Kg]", 5, true }
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
                columns: new[] { "Name", "ReportId", "DataTypeId", "Value" },
                values: new object[,]
                {
                    { "Proveedor", 1, 2, "Constructura X SRL" },
                    { "Tel. Proveedor", 1, 1, "42561873" },
                    { "Alto [mm]", 2, 1, "180" },
                    { "Ancho [mm]", 2, 1, "270" },
                    { "Peso [kg]", 2, 5, "58.8" },
                    { "Proveedor", 3, 2, "Constructura X SRL" },
                    { "Tel. Proveedor", 3, 1, "42561873" }
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

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _init : Migration
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
                name: "DeptoTemplate",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptoId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeptoTemplate", x => x.TemplateId);
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
                name: "FieldTemplate",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    DataTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTemplate", x => new { x.TemplateId, x.Label });
                    table.ForeignKey(
                        name: "FK_FieldTemplate_DataType_DataTypeId",
                        column: x => x.DataTypeId,
                        principalTable: "DataType",
                        principalColumn: "DataTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldTemplate_DeptoTemplate_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "DeptoTemplate",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Cascade);
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
                table: "DeptoTemplate",
                columns: new[] { "TemplateId", "DeptoId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Auto Propio" },
                    { 2, 1, "Servicio Viaje" },
                    { 3, 1, "Viaticos" },
                    { 4, 2, "Material.Const." },
                    { 5, 2, "Viaticos" }
                });

            migrationBuilder.InsertData(
                table: "ReportOperations",
                columns: new[] { "ReportOperationId", "ReportOperationName" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "Aceptado" },
                    { 3, "Rechazado" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "ReportId", "Amount", "Description", "EmployeeId" },
                values: new object[,]
                {
                    { 1, 7500.0, "Bolsa de cemento", 1 },
                    { 2, 15000.0, "Placa Mdf", 1 }
                });

            migrationBuilder.InsertData(
                table: "FieldTemplate",
                columns: new[] { "Label", "TemplateId", "DataTypeId", "Enabled" },
                values: new object[,]
                {
                    { "Destino", 1, 2, true },
                    { "Fecha", 1, 3, true },
                    { "Km", 1, 5, true },
                    { "Monto Peajes", 1, 5, true },
                    { "Peajes", 1, 4, true },
                    { "Comprobante", 2, 2, true },
                    { "Destino", 2, 2, true },
                    { "Fecha", 2, 3, true },
                    { "Nombre Servicio", 2, 2, true },
                    { "Comprobante", 3, 2, true },
                    { "Fecha", 3, 3, true },
                    { "Motivo", 3, 2, true },
                    { "Viatico", 3, 2, true },
                    { "Alto [mm]", 4, 5, true },
                    { "Ancho [mm]", 4, 5, true },
                    { "Contacto", 4, 1, true },
                    { "Fecha", 4, 3, true },
                    { "Nombre Material", 4, 2, true },
                    { "Peso [Kg]", 4, 5, true },
                    { "Proveedor", 4, 2, true },
                    { "Comprobante", 5, 2, true },
                    { "Fecha", 5, 3, true },
                    { "Motivo", 5, 2, true },
                    { "Viatico", 5, 2, true }
                });

            migrationBuilder.InsertData(
                table: "ReportTrackings",
                columns: new[] { "ReportTrackingId", "DateTracking", "EmployeeId", "ReportId", "ReportOperationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 16, 18, 30, 23, 343, DateTimeKind.Local).AddTicks(7787), 1, 1, 1 },
                    { 2, new DateTime(2023, 9, 16, 18, 30, 23, 343, DateTimeKind.Local).AddTicks(7798), 1, 2, 1 }
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
                    { "Peso[kg]", 2, 5, "58.8" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldTemplate_DataTypeId",
                table: "FieldTemplate",
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
                name: "FieldTemplate");

            migrationBuilder.DropTable(
                name: "ReportTrackings");

            migrationBuilder.DropTable(
                name: "VariableFields");

            migrationBuilder.DropTable(
                name: "DeptoTemplate");

            migrationBuilder.DropTable(
                name: "ReportOperations");

            migrationBuilder.DropTable(
                name: "DataType");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}

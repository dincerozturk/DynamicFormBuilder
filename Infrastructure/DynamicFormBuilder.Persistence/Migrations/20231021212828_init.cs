using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicFormBuilder.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "DynamicFormBuilderSequence");

            migrationBuilder.CreateTable(
                name: "FormSpec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalAttribute = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSpec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldSpec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FormSpecId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElementTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ElementInputTypeId = table.Column<byte>(type: "tinyint", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    AdditionalAttribute = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldSpec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldSpec_FormSpec_FormSpecId",
                        column: x => x.FormSpecId,
                        principalTable: "FormSpec",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormSubmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FormSpecId = table.Column<int>(type: "int", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormSubmission_FormSpec_FormSpecId",
                        column: x => x.FormSpecId,
                        principalTable: "FormSpec",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FieldData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FieldSpecId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldData_FieldSpec_FieldSpecId",
                        column: x => x.FieldSpecId,
                        principalTable: "FieldSpec",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldData_FieldSpecId",
                table: "FieldData",
                column: "FieldSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSpec_FormSpecId",
                table: "FieldSpec",
                column: "FormSpecId");

            migrationBuilder.CreateIndex(
                name: "IX_FormSubmission_FormSpecId",
                table: "FormSubmission",
                column: "FormSpecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldData");

            migrationBuilder.DropTable(
                name: "FormSubmission");

            migrationBuilder.DropTable(
                name: "FieldSpec");

            migrationBuilder.DropTable(
                name: "FormSpec");

            migrationBuilder.DropSequence(
                name: "DynamicFormBuilderSequence");
        }
    }
}

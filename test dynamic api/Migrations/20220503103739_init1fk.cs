using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_dynamic_api.Migrations
{
    public partial class init1fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "number",
            //    table: "Registration",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            migrationBuilder.CreateTable(
                name: "CreateTableData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateTableData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreateTableField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableIdRef = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateTableField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreateTableField_CreateTableData_CreateModelId",
                        column: x => x.CreateModelId,
                        principalTable: "CreateTableData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreateTableField_CreateModelId",
                table: "CreateTableField",
                column: "CreateModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateTableField");

            migrationBuilder.DropTable(
                name: "CreateTableData");

            migrationBuilder.AlterColumn<int>(
                name: "number",
                table: "Registration",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class add_documentDelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Deliveries_DeliveryId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DeliveryId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "UserTeachers",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 14:15:41");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "UserStudents",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 14:15:41");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Roles",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 14:15:41");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Posts",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 14:15:41");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Documents",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 14:15:41");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Deliveries",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 14:15:41");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Classrooms",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 14:15:41");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Assignments",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 14:15:41");

            migrationBuilder.CreateTable(
                name: "documentDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<string>(nullable: true, defaultValue: "05/20/2020 17:24:10"),
                    Name = table.Column<string>(nullable: true),
                    Format = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    DeliveryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_documentDeliveries_Deliveries_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_documentDeliveries_DeliveryId",
                table: "documentDeliveries",
                column: "DeliveryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documentDeliveries");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "UserTeachers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 14:15:41",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "UserStudents",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 14:15:41",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 14:15:41",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 14:15:41",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 14:15:41",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 14:15:41",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Classrooms",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 14:15:41",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 14:15:41",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DeliveryId",
                table: "Documents",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Deliveries_DeliveryId",
                table: "Documents",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

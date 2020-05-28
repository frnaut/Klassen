using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class z : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "UserTeachers",
                nullable: true,
                defaultValue: "05/28/2020 09:23:42",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "UserStudents",
                nullable: true,
                defaultValue: "05/28/2020 09:23:42",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Roles",
                nullable: true,
                defaultValue: "05/28/2020 09:23:42",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Posts",
                nullable: true,
                defaultValue: "05/28/2020 09:23:42",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Documents",
                nullable: true,
                defaultValue: "05/28/2020 09:23:42",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "documentDeliveries",
                nullable: true,
                defaultValue: "05/28/2020 09:23:42",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "documentDeliveries",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Deliveries",
                nullable: true,
                defaultValue: "05/28/2020 09:23:42",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Classrooms",
                nullable: true,
                defaultValue: "05/28/2020 09:23:42",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Assignments",
                nullable: true,
                defaultValue: "05/28/2020 09:23:42",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "05/20/2020 17:24:10");

            migrationBuilder.AddColumn<int>(
                name: "ClassroomId",
                table: "Assignments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Assignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_documentDeliveries_StudentId",
                table: "documentDeliveries",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassroomId",
                table: "Assignments",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherId",
                table: "Assignments",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Classrooms_ClassroomId",
                table: "Assignments",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_UserTeachers_TeacherId",
                table: "Assignments",
                column: "TeacherId",
                principalTable: "UserTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_documentDeliveries_UserStudents_StudentId",
                table: "documentDeliveries",
                column: "StudentId",
                principalTable: "UserStudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Classrooms_ClassroomId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_UserTeachers_TeacherId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_documentDeliveries_UserStudents_StudentId",
                table: "documentDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_documentDeliveries_StudentId",
                table: "documentDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_ClassroomId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_TeacherId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "documentDeliveries");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Assignments");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "UserTeachers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/28/2020 09:23:42");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "UserStudents",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/28/2020 09:23:42");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/28/2020 09:23:42");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/28/2020 09:23:42");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/28/2020 09:23:42");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "documentDeliveries",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/28/2020 09:23:42");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/28/2020 09:23:42");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Classrooms",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/28/2020 09:23:42");

            migrationBuilder.AlterColumn<string>(
                name: "Created",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "05/20/2020 17:24:10",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "05/28/2020 09:23:42");
        }
    }
}

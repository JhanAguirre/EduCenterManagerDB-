using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCenterManagerDB.Migrations
{
   
    public partial class FixCalificacionesDelete : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Cursos_IdCurso",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Estudiantes_IdEstudiante",
                table: "Calificaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Cursos_IdCurso",
                table: "Calificaciones",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "IdCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Estudiantes_IdEstudiante",
                table: "Calificaciones",
                column: "IdEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "IdEstudiante");
        }

       
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Cursos_IdCurso",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Estudiantes_IdEstudiante",
                table: "Calificaciones");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Cursos_IdCurso",
                table: "Calificaciones",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Estudiantes_IdEstudiante",
                table: "Calificaciones",
                column: "IdEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "IdEstudiante",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

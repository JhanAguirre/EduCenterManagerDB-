using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduCenterManagerDB.Migrations
{

    public partial class UpdateDeleteBehavior : Migration
    {
      
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Cursos_IdCurso",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Estudiantes_IdEstudiante",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Profesores_IdProfesor",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Cursos_IdCurso",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Cursos_IdCurso",
                table: "Horarios");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Profesores_IdProfesor",
                table: "Cursos",
                column: "IdProfesor",
                principalTable: "Profesores",
                principalColumn: "IdProfesor",
                onDelete: ReferentialAction.Cascade);   

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Cursos_IdCurso",
                table: "Estudiantes",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Cursos_IdCurso",
                table: "Horarios",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Cascade);
        }

       
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Cursos_IdCurso",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Estudiantes_IdEstudiante",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Profesores_IdProfesor",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Cursos_IdCurso",
                table: "Estudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Horarios_Cursos_IdCurso",
                table: "Horarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Cursos_IdCurso",
                table: "Calificaciones",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Estudiantes_IdEstudiante",
                table: "Calificaciones",
                column: "IdEstudiante",
                principalTable: "Estudiantes",
                principalColumn: "IdEstudiante",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Profesores_IdProfesor",
                table: "Cursos",
                column: "IdProfesor",
                principalTable: "Profesores",
                principalColumn: "IdProfesor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Cursos_IdCurso",
                table: "Estudiantes",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Horarios_Cursos_IdCurso",
                table: "Horarios",
                column: "IdCurso",
                principalTable: "Cursos",
                principalColumn: "IdCurso",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

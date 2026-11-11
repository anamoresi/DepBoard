using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepBoard.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    IdDisciplina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdExterno = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.IdDisciplina);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Alunos_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaCursos",
                columns: table => new
                {
                    IdDisciplinaCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    IdDisciplina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaCursos", x => x.IdDisciplinaCurso);
                    table.ForeignKey(
                        name: "FK_DisciplinaCursos_Cursos_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaCursos_Disciplinas_IdDisciplina",
                        column: x => x.IdDisciplina,
                        principalTable: "Disciplinas",
                        principalColumn: "IdDisciplina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    IdNota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    IdDisciplinaCurso = table.Column<int>(type: "int", nullable: false),
                    Perletivo = table.Column<int>(type: "int", nullable: false),
                    Av1 = table.Column<double>(type: "float", nullable: false),
                    Av2 = table.Column<double>(type: "float", nullable: false),
                    SegundaChamada = table.Column<double>(type: "float", nullable: false),
                    ProvaFinal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.IdNota);
                    table.ForeignKey(
                        name: "FK_Notas_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notas_DisciplinaCursos_IdDisciplinaCurso",
                        column: x => x.IdDisciplinaCurso,
                        principalTable: "DisciplinaCursos",
                        principalColumn: "IdDisciplinaCurso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdCurso",
                table: "Alunos",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaCursos_IdCurso",
                table: "DisciplinaCursos",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaCursos_IdDisciplina",
                table: "DisciplinaCursos",
                column: "IdDisciplina");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdAluno",
                table: "Notas",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdDisciplinaCurso",
                table: "Notas",
                column: "IdDisciplinaCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "DisciplinaCursos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Disciplinas");
        }
    }
}

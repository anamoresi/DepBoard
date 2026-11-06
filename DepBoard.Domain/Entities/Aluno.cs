namespace DepBoard.Domain.Entities
{
    public class Aluno
    {
        public int IdAluno { get; private set; }

        public int IdCurso { get; private set; }
        public Curso Curso { get; private set; } = null!;

        public ICollection<Nota> Notas { get; private set; } = new List<Nota>();

        public string Matricula { get; private set; } = string.Empty;
        public string Nome { get; private set; } = string.Empty;

        // Construtores //
        private Aluno(){}

        public Aluno(Curso curso, string matricula, string nome)
        {
            this.Curso = curso;
            this.Matricula = matricula;
            this.Nome = nome;
        }
    }
}

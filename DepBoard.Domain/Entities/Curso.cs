using DepBoard.Domain.Enums;

namespace DepBoard.Domain.Entities
{
    public class Curso
    {
        public int IdCurso { get; private set; }

        // Navigations //
        public ICollection<Aluno> Alunos { get; private set; } = new List<Aluno>();
        public ICollection<DisciplinaCurso> DisciplinaCursos { get; private set; } = new List<DisciplinaCurso>();

        public string Nome { get; private set; } = string.Empty;
        public UnidadeEnum Unidade { get; private set; }
        public TurnoEnum Turno { get; private set; }

        private Curso(){}

        public Curso(string nome, UnidadeEnum unidade, TurnoEnum turno)
        {
            this.Nome = nome;
            this.Unidade = unidade;
            this.Turno = turno;
        }
    }
}

namespace DepBoard.Domain.Entities
{
    public class Disciplina
    {
        public int IdDisciplina { get; private set; }
        public int IdExterno { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        
        public ICollection<DisciplinaCurso> DisciplinaCursos { get; private set; } = new List<DisciplinaCurso>();

        private Disciplina(){}

        public Disciplina (int idExterno, string nome)
        {
            this.IdExterno = idExterno;
            this.Nome = nome;
        }
    }
}

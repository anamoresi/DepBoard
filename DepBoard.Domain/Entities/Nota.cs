namespace DepBoard.Domain.Entities
{
    public class Nota
    {
        public int IdNota { get; private set; }

        public int IdAluno { get; private set; }
        public Aluno Aluno { get; private set; } = null!;

        public int IdDisciplinaCurso { get; private set; }
        public DisciplinaCurso DisciplinaCurso { get; private set; } = null!;

        public string Perletivo { get; private set; } = string.Empty;
        public double? AV1 { get; private set; }
        public double? AV2 { get; private set; }
        public double? SegundaChamada { get; private set; }
        public double? ProvaFinal { get; private set; }

        private Nota(){}

        public Nota(
            Aluno aluno,
            DisciplinaCurso disciplinaCurso,
            string perletivo,
            double av1,
            double av2,
            double segundaChamada,
            double provaFinal)
        {
            this.Aluno = aluno;
            this.DisciplinaCurso = disciplinaCurso;
            this.Perletivo = perletivo;
            this.AV1 = av1;
            this.AV2 = av2;
            this.SegundaChamada = segundaChamada;
            this.ProvaFinal = provaFinal;
        }
    }
}

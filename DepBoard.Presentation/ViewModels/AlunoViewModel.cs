namespace DepBoard.Presentation.ViewModels
{
    public record OpcaoViewModel(int Id, string Nome);

    public record DisciplinaNotaViewModel(
        string Disciplina,
        string Perletivo,
        double? AV1,
        double? AV2,
        double? SegundaChamada,
        double? ProvaFinal,
        double? Media
        );

    public record AlunoViewModel(
        string Nome,
        string Matricula,
        string Curso,
        double? MediaGeral,
        List<DisciplinaNotaViewModel> Disciplinas);

    public class AlunosIndexViewModel
    {
        public List<AlunoViewModel> Alunos { get; init; } = new();

        // Paginação
        public int Pagina { get; init; } = 1;
        public int TotalPaginas { get; init; } = 1;
        public int TotalAlunos { get; init; }

        public string? Nome { get; init; }
        public int? IdCurso { get; init; }
        public string? Media { get; init; }
        public List<string> PerletivosSelecionados { get; init; } = new();

        public List<OpcaoViewModel> Cursos { get; init; } = new();
        public List<string> PerletivosDisponiveis { get; init; } = new();
    }
}
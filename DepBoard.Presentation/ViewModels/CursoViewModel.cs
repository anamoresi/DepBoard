using DepBoard.Domain.Enums;

namespace DepBoard.Presentation.ViewModels
{
    public class CursoViewModel
    {
        public string Nome { get; init; } = string.Empty;
        public UnidadeEnum Unidade { get; init; }
        public TurnoEnum Turno { get; init; }

        public CursoViewModel(string nome, UnidadeEnum unidade, TurnoEnum turno)
        {
            Nome = nome;
            Unidade = unidade;
            Turno = turno;
        }
    }


}

using DepBoard.Domain.Entities;

namespace DepBoard.Presentation.ViewModels
{
    public class AlunoViewModel
    {
        public string Nome { get; init; }
        public string Matricula { get; init; }
        public string Curso { get; init; }
        public List<Nota> Notas { get; init; }

        public AlunoViewModel (string nome, string matricula, string curso, List<Nota> notas)
        {
            Nome = nome;
            Matricula = matricula;
            Curso = curso;
            Notas = notas;
        }
    }
}

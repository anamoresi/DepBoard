namespace DepBoard.Presentation.ViewModels
{
    public class DisciplinaViewModel
    {
        public string Nome { get; init; }
        public int IdExterno { get; init; }


        public DisciplinaViewModel (string nome, int idExterno)
        {
            Nome = nome;
            IdExterno = idExterno;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepBoard.Domain.Entities
{
    public class Professor
    {
        public int IdProfessor { get; private set; }
        public int Matricula { get; private set; }
        public string Nome { get; private set; } = string.Empty;

        public ICollection<DisciplinaCurso> DisciplinaCursos = new List<DisciplinaCurso>();

        public Professor(int matricula, string nome)
        {
            Matricula = matricula;
            Nome = nome;
        }
    }

    


}

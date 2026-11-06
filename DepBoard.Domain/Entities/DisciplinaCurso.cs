using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepBoard.Domain.Entities
{
    public class DisciplinaCurso
    {
        public int IdDisciplinaCurso { get; private set; }

        public int IdCurso { get; private set; }
        public Curso Curso { get; private set; } = null!;

        public int IdDisciplina { get; private set; }
        public Disciplina Disciplina { get; private set; } = null!;

        public ICollection<Nota> Notas { get; private set; } = new List<Nota>();

        private DisciplinaCurso(){}
        
        public DisciplinaCurso(Curso curso, Disciplina disciplina)
        {
            this.Curso = curso;
            this.Disciplina = disciplina;
        }
    }
}

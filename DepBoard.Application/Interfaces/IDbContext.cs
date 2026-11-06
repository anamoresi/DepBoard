using DepBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepBoard.Application.Interfaces
{
    public interface IDbContext
    {
        public DbSet<Aluno> Alunos { get; }
        public DbSet<Curso> Cursos { get; }
        public DbSet<Disciplina> Disciplinas { get; }
        public DbSet<Nota> Notas { get; }
        public DbSet<DisciplinaCurso> DisciplinaCursos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

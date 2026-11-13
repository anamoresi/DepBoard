using DepBoard.Application.Interfaces;
using DepBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepBoard.Application.Services
{
    public class AlunosServices(IDbContext context)
    {
        public IDbContext _contexto = context;

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _contexto.Alunos
                .Include(a => a.Curso)
                .ToListAsync();
        }

        public async Task<Aluno?> GetAlunoByMatricula(string matricula)
        {
            return await _contexto.Alunos
                .FirstOrDefaultAsync(a => a.Matricula == matricula);
        }

        public async Task<ICollection<Aluno>> GetAlunosByCurso(int idCurso)
        {
            return await _contexto.Alunos
                .Where(a=> a.IdCurso == idCurso)
                .ToListAsync();
        }

        public async Task<List<Aluno>> GetAlunosFiltrados(string? nome, int? idCurso)
        {
            IQueryable<Aluno> query = _contexto.Alunos
                .AsNoTracking()
                .Include(a => a.Curso)
                .Include(a => a.Notas)
                    .ThenInclude(n => n.DisciplinaCurso)
                        .ThenInclude(dc => dc.Disciplina);

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(a => a.Nome.Contains(nome));

            if (idCurso.HasValue)
                query = query.Where(a => a.IdCurso == idCurso.Value);

            return await query
                .OrderBy(a => a.Nome)
                .ToListAsync();
        }

        public async Task<List<string>> GetPerletivos()
        {
            return await _contexto.Notas
                .Select(n => n.Perletivo)
                .Distinct()
                .OrderBy(p => p)
                .ToListAsync();
        }
    }
}

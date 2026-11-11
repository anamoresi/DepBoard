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
    }
}

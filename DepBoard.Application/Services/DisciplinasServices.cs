using DepBoard.Application.Interfaces;
using DepBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DepBoard.Application.Services
{
    public class DisciplinasServices
    {
        private readonly IDbContext _dbContext;

        public DisciplinasServices(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Disciplina>> GetDisciplinas()
        {
            return await _dbContext.Disciplinas.ToListAsync();
        }
    }
}

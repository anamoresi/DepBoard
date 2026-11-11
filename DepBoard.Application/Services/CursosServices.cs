using DepBoard.Application.Interfaces;
using DepBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DepBoard.Application.Services
{
    public class CursosServices
    {
        private readonly IDbContext _dbContext;

        public CursosServices(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Curso>> GetAllCursos()
        {
            return await _dbContext.Cursos.ToListAsync();
            //puxa todos os cursos do banco e cria uma lista com todos eles e retorna essa lista
        }
    }
}

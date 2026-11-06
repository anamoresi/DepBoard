using DepBoard.Application.Interfaces;
using DepBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepBoard.Application.Services
{
    public class CursosServices
    {
        private readonly IDbContext _dbContext;

        public CursosServices(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Curso> GetCursoPeloIdAsync(int idCurso)
        {
            //implemente ai tropa ass: Filipe
            throw new NotImplementedException();//tu bota isso daq quando vc nao quer implmentar uma funcao mas nao quer q dê erro tlg
        }

        public async Task<List<Curso>> GeAllCursos()
        {
            return await _dbContext.Cursos.ToListAsync();//puxa todos os cursos do banco e cria uma lista com todos eles e retorna essa lista
        }


    }
}

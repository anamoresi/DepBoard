using DepBoard.Application.Services;
using DepBoard.Domain.Entities;
using DepBoard.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DepBoard.Presentation.Controllers
{
    public class AlunosController: Controller
    {
        private readonly AlunosServices _alunosServices;

        public AlunosController(AlunosServices alunosServices)
        {
            _alunosServices = alunosServices;
        }

        public async Task<IActionResult> Index()
        {
            List<Aluno> alunos = await _alunosServices.GetAlunos();
            var listaAlunosViewModel = alunos.Select(a => new AlunoViewModel(
                nome: a.Nome,
                matricula: a.Matricula,
                curso: a.Curso.Nome,
                notas: a.Notas.ToList()
                )).ToList();

            return View(listaAlunosViewModel);
        }
    }
}

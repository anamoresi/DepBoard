using DepBoard.Application.Services;
using Microsoft.AspNetCore.Mvc;
using DepBoard.Presentation.ViewModels;

namespace DepBoard.Presentation.Controllers
{
    public class CursosController : Controller
    {
        private readonly CursosServices _cursosServices;

        public CursosController(CursosServices cursosServices)
        {
            _cursosServices = cursosServices;
        }

        public async Task<IActionResult> Index()
        {
            var cursos = await _cursosServices.GetAllCursos();
            var listaCursosViewModel = cursos.Select(c => new CursoViewModel(
                nome: c.Nome,
                unidade: c.Unidade,
                turno: c.Turno
                )).ToList();

            return View(listaCursosViewModel);
        }
    }
}

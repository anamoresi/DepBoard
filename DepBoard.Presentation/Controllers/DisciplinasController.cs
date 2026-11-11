using DepBoard.Application.Services;
using Microsoft.AspNetCore.Mvc;
using DepBoard.Presentation.ViewModels;

namespace DepBoard.Presentation.Controllers
{
    public class DisciplinasController : Controller
    {
        private readonly DisciplinasServices _disciplinasServices;

        public DisciplinasController(DisciplinasServices disciplinasServices)
        {
            _disciplinasServices = disciplinasServices;
        }

        public async Task<IActionResult> Index()
        {
            var disciplinas = await _disciplinasServices.GetDisciplinas();
            var listaDisciplinasViewModel = disciplinas.Select(d => new DisciplinaViewModel(
                nome: d.Nome,
                idExterno: d.IdExterno
                )).ToList();
            return View(listaDisciplinasViewModel);
        }
    }
}

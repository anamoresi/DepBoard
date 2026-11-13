using DepBoard.Application.Services;
using DepBoard.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DepBoard.Presentation.Controllers
{
    public class AlunosController : Controller
    {
        private const int TamanhoPagina = 20;

        private readonly AlunosServices _alunosServices;
        private readonly CursosServices _cursosServices;

        public AlunosController(AlunosServices alunosServices, CursosServices cursosServices)
        {
            _alunosServices = alunosServices;
            _cursosServices = cursosServices;
        }

        public async Task<IActionResult> Index(string? nome, int? idCurso, string? media, List<string>? perletivo, int pagina = 1)
        {
            var selecionados = perletivo ?? new List<string>();
            var alunos = await _alunosServices.GetAlunosFiltrados(nome, idCurso);

            var lista = alunos.Select(a =>
            {
                var disciplinas = a.Notas
                    .Where(n => selecionados.Count == 0 || selecionados.Contains(n.Perletivo))
                    .OrderBy(n => n.Perletivo)
                    .ThenBy(n => n.DisciplinaCurso.Disciplina.Nome)
                    .Select(n =>
                    {
                        var r = CalculadoraNotas.Calcular(n);
                        return new DisciplinaNotaViewModel(
                            n.DisciplinaCurso.Disciplina.Nome, n.Perletivo,
                            n.AV1, n.AV2, n.SegundaChamada, n.ProvaFinal,
                            r.Media);
                    })
                    .ToList();

                var medias = disciplinas.Where(d => d.Media.HasValue).Select(d => d.Media!.Value).ToList();
                double? geral = medias.Count > 0 ? medias.Average() : null;

                return new AlunoViewModel(a.Nome, a.Matricula, a.Curso.Nome, geral, disciplinas);
            }).ToList();

            if (selecionados.Count > 0)
                lista = lista.Where(a => a.Disciplinas.Count > 0).ToList();

            if (media == "maior")
                lista = lista.Where(a => a.MediaGeral >= CalculadoraNotas.MediaAprovacao).ToList();
            else if (media == "menor")
                lista = lista.Where(a => a.MediaGeral < CalculadoraNotas.MediaAprovacao).ToList();

            // Paginação: pega só a fatia da página atual
            int totalAlunos = lista.Count;
            int totalPaginas = Math.Max(1, (int)Math.Ceiling(totalAlunos / (double)TamanhoPagina));
            pagina = Math.Clamp(pagina, 1, totalPaginas);

            var paginaAtual = lista
                .Skip((pagina - 1) * TamanhoPagina)
                .Take(TamanhoPagina)
                .ToList();

            var cursos = await _cursosServices.GetAllCursos();

            var model = new AlunosIndexViewModel
            {
                Alunos = paginaAtual,
                Pagina = pagina,
                TotalPaginas = totalPaginas,
                TotalAlunos = totalAlunos,
                Nome = nome,
                IdCurso = idCurso,
                Media = media,
                PerletivosSelecionados = selecionados,
                Cursos = cursos.OrderBy(c => c.Nome).Select(c => new OpcaoViewModel(c.IdCurso, c.Nome)).ToList(),
                PerletivosDisponiveis = await _alunosServices.GetPerletivos()
            };

            return View(model);
        }
    }
}
using DepBoard.Domain.Entities;

namespace DepBoard.Application.Services
{
    public static class CalculadoraNotas
    {
        public const double MediaAprovacao = 7.0;
        public const double MediaAprovacaoFinal = 5.0;

        public record ResultadoNota(double? Media);

        public static ResultadoNota Calcular(Nota nota)
        {
            var av1 = nota.AV1;
            var av2 = nota.AV2;

            if (nota.SegundaChamada is double sc)
            {
                if (av1 is null) av1 = sc;
                else if (av2 is null) av2 = sc;
                else if (av1 <= av2 && sc > av1) av1 = sc;
                else if (av2 < av1 && sc > av2) av2 = sc;
            }

            if (av1 is null || av2 is null)
                return new ResultadoNota(null);

            double media = (av1.Value + av2.Value) / 2;

            if (media >= MediaAprovacao)
                return new ResultadoNota(media);

            if (nota.ProvaFinal is double pf)
            {
                double mediaFinal = (media + pf) / 2;
                return new ResultadoNota(mediaFinal);
            }

            return new ResultadoNota(media);
        }
    }
}
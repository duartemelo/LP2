/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using CorporacaoBO;
using CorporacaoBR;
using IncendioBO;
using IncendioBR;
using System;

namespace LP2
{
    class Program
    {
        /// <summary>
        /// Program.cs, "ponto de partida" para inicialização do programa.
        /// Este program.cs chamará, futuramente, um menu que consequentemente realiza todas as operações necessárias.
        /// Neste momento é responsável pela execução de testes.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            

            Corporacao corporacao = new Corporacao();
            corporacao.Tipo = TipoCorp.Voluntarios;
            corporacao.Freguesia = "Maximinos";
            CorporacaoRegras.InsereCorporacao(corporacao);

            CorporacaoRegras.MostraCorporacoes();

            Console.WriteLine("----");

            Incendio incendio = new Incendio();
            incendio.Tipo = TipoIncendio.Florestal;
            float[] coordenadas = { 100, 200 };
            incendio.Coordenadas = coordenadas;
            incendio.AdicionarOperacional(1);
            incendio.AdicionarOperacional(1);
            incendio.AdicionarOperacional(2);

            IncendioRegras.InsereIncendio(incendio);

            IncendioRegras.MostraIncendios();


            Console.ReadKey();



        }
    }
}

/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using CorporacaoBO;
using CorporacaoBR;
using IncendioBO;
using IncendioBR;
using OperacionalBO;
using OperacionalBR;
using System;
using Menu;

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


            /*Corporacao corporacao = new Corporacao();
            corporacao.Tipo = TipoCorp.Voluntarios;
            corporacao.Freguesia = "Maximinos";
            CorporacaoRegras.InsereCorporacao(corporacao);

            CorporacaoRegras.MostraCorporacoes();

            Console.WriteLine("----");

            Incendio incendio = new Incendio();
            incendio.Tipo = TipoIncendio.Florestal;
            float[] coordenadas = { 100, 200 };
            incendio.Coordenadas = coordenadas;

            IncendioRegras.InsereIncendio(incendio);
            //incendio.AdicionarOperacional(1);
            //incendio.AdicionarOperacional(1);
            //incendio.AdicionarOperacional(2);



            IncendioRegras.AdicionarOperacionalIncendio(1, 1); // nao adiciona porque operacional nao existe

            Operacional o1 = new Operacional();
            Operacional o2 = new Operacional();
            Operacional o3 = new Operacional();
            o1.Cc = 12345;
            o1.Nome = "Duarte";
            //o1.Estado = EstadoOperacional.Ativo;

            

            o2.Cc = 12344;
            o2.Nome = "Joana";
            //o2.Estado = EstadoOperacional.Ativo;

            o3.Cc = 12333;
            o3.Nome = "Barbara";
            //o3.Estado = EstadoOperacional.Ativo;

            OperacionalRegras.InsereOperacional(o1);
            OperacionalRegras.InsereOperacional(o2);
            OperacionalRegras.InsereOperacional(o3);

            OperacionalRegras.AdicionarOperacionalACorporacao(1, 1);
            


            OperacionalRegras.MostraOperacionais();
            Console.WriteLine("----");




            IncendioRegras.AdicionarOperacionalIncendio(1, 1);
            IncendioRegras.AdicionarOperacionalIncendio(1, 1);
            IncendioRegras.AdicionarOperacionalIncendio(3, 1);
            IncendioRegras.AdicionarOperacionalIncendio(5, 1);



            IncendioRegras.MostraIncendios();

            //MenuIO.WriteMenu();
            */

            MenuIO.UserInterface();

            Console.ReadKey();



        }
    }
}

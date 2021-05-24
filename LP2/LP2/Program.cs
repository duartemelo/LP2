/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using CorporacaoBO;
using CorporacaoBR;
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
            /*Incendios incendios = new Incendios();
            float[] coordenadas = { -100, 100 };
            float[] coordenadas2 = { -200, 200 };

            incendios.CriarNovoIncendio("florestal", coordenadas);



            incendios.CriarNovoIncendio("florestal", coordenadas, Estado.Extinto);

            incendios.CriarNovoIncendio("florestal", coordenadas2);


            incendios.MostrarIncendios();

            Console.WriteLine();*/

            Corporacao corporacao = new Corporacao();
            corporacao.Tipo = Tipo.Voluntarios;
            corporacao.Freguesia = "Maximinos";
            CorporacaoRegras.InsereCorporacao(corporacao);

            CorporacaoRegras.MostraCorporacoes();

            Console.ReadKey();
            

            

            /*Console.WriteLine();

            Viaturas viaturas = new Viaturas();

            //como criar viatura sem matricula? por exemplo helicoptero (arranjar solução)
            //passar corporacao como parametro?
            viaturas.CriarNovaViatura(0, "carro", "00-AA-00", "Opel", "Corsa", "ativo");
            viaturas.CriarNovaViatura(0, "carro", "01-BB-01", "Fiat", "Punto", "ativo");
            viaturas.CriarNovaViatura(0, "heli", null, "MarcaHeli", "ModeloHeli", "ativo");
            viaturas.MostrarViaturas();
            //viaturas.RemoverViaturaId(0);
            //viaturas.MostrarViaturas();

            Console.ReadKey();

            

            /*Classes que faltam:
             * Operacionais
             * Operacional
             */

            
            
        }
    }
}

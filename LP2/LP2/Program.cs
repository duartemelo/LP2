﻿/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Incendios incendios = new Incendios();
            float[] coordenadas = { -100, 100 };
            float[] coordenadas2 = { -200, 200 };

            incendios.CriarNovoIncendio("florestal", coordenadas);



            incendios.CriarNovoIncendio("florestal", coordenadas, Estado.Extinto);

            incendios.CriarNovoIncendio("florestal", coordenadas2);


            incendios.MostrarIncendios();

            Console.WriteLine();

            Corporacoes corporacoes = new Corporacoes();
            corporacoes.CriarNovaCorporacao("Maximinos", "Bombeiros Voluntarios");
            corporacoes.CriarNovaCorporacao("Gaia", "Bombeiros Sapadores");

            corporacoes.MostrarCorporacoes();

            Console.WriteLine();

            Viaturas viaturas = new Viaturas();

            //como criar viatura sem matricula? por exemplo helicoptero (arranjar solução)
            //passar corporacao como parametro?
            viaturas.CriarNovaViatura(0, "carro", "00-AA-00", "Opel", "Corsa", "ativo");
            viaturas.CriarNovaViatura(0, "carro", "01-BB-01", "Fiat", "Punto", "ativo");
            viaturas.MostrarViaturas();
            viaturas.RemoverViaturaId(0);
            viaturas.MostrarViaturas();

            Console.ReadKey();

            

            /*Classes que faltam:
             * Operacionais
             * Operacional
             */
            
        }
    }
}

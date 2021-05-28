/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using System;
using CorporacaoBO;
using CorporacaoBR;

namespace CorporacaoInput
{
    /// <summary>
    /// Class responsável pela interação com o utilizador, no que diz respeito às corporações
    /// </summary>
    public class CorporacaoInputs
    {
        /// <summary>
        /// Interação para criar uma corporação
        /// </summary>
        /// <returns>Sucesso da criação (true se adicionou, false se não)</returns>
        public static bool CriarCorporacao()
        {
            Corporacao c1 = new Corporacao();

            Console.WriteLine("Freguesia: ");
            c1.Freguesia = Console.ReadLine();
            Console.WriteLine("Tipo: ");
            string tipo = Console.ReadLine();
            tipo = tipo.ToLower();
            while (tipo != "voluntarios" && tipo != "sapadores")
            {
                Console.WriteLine("Tipo: ");
                tipo = Console.ReadLine();
                tipo = tipo.ToLower();
            }
            if (tipo == "voluntarios")
                c1.Tipo = TipoCorp.Voluntarios;
            else if (tipo == "sapadores")
                c1.Tipo = TipoCorp.Sapadores;

            return CorporacaoRegras.InsereCorporacao(c1);
        }

        /// <summary>
        /// Interação para a remoção de uma corporação
        /// </summary>
        /// <returns></returns>
        public static bool RemoveCorporacao()
        {
            //REMOVER TODOS OS BOMBEIROS DESTA CORP!!!!! to-do
            Console.WriteLine("ID corporacao: "); 
            int id = int.Parse(Console.ReadLine());
            return (CorporacaoRegras.RemoveCorporacao(CorporacaoRegras.DevolveCorporacaoPeloId(id)));
        }
    }
}

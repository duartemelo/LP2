/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using System.Collections.Generic;
using CorporacaoBO;

namespace CorporacaoOutput
{
    /// <summary>
    /// Class / Library responsável pelos outputs das corporações
    /// </summary>
    public class CorporacaoEscreve
    {
        /// <summary>
        /// Mostra uma corporação
        /// </summary>
        /// <param name="c">Corporação a mostrar</param>
        public static void MostraCorporacao (Corporacao c)
        {
            Console.WriteLine(c.ToString());
        }

        /// <summary>
        /// Mostra uma lista de corporações
        /// </summary>
        /// <param name="corporacoes">Recebe a lista de corporações para mostrar</param>
        public static void MostraCorporacoes(List<Corporacao> corporacoes)
        {
            foreach (Corporacao corporacao in corporacoes)
            {
                 MostraCorporacao(corporacao);
            }
            
        }

        

        
    }
}

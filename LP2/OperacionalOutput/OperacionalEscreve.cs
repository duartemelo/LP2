/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using System;
using OperacionalBO;
using System.Collections.Generic;

namespace OperacionalOutput
{
    /// <summary>
    /// Class responsável por mostrar/printar o que seja relativo ao objeto operacional
    /// </summary>
    public class OperacionalEscreve
    {
        /// <summary>
        /// Mostra um operacional
        /// </summary>
        /// <param name="o">Operacional a mostrar</param>
        public static void MostraOperacional (Operacional o)
        {
            Console.WriteLine(o.ToString());
        }

        /// <summary>
        /// Mostra a lista de operacionais
        /// </summary>
        /// <param name="operacionais">Lista de operacionais</param>
        public static void MostraOperacionais (List<Operacional> operacionais)
        {
            foreach (Operacional operacional in operacionais)
            {
                MostraOperacional(operacional);
            }
        }
    }
}

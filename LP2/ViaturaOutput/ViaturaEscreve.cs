using System;
using System.Collections.Generic;
using ViaturaBO;

namespace ViaturaOutput
{
    /// <summary>
    /// Class responsável por mostrar/printar viaturas
    /// </summary>
    public class ViaturaEscreve
    {
        /// <summary>
        /// Mostra uma viatura
        /// </summary>
        /// <param name="v">Viatura a mostrar</param>
        public static void MostraViatura(Viatura v)
        {
            Console.WriteLine(v.ToString());
        }

        /// <summary>
        /// Mostra a lista de viaturas
        /// </summary>
        /// <param name="viaturas">Lista de viaturas</param>
        public static void MostraViaturas(List<Viatura> viaturas)
        {
            foreach (Viatura viatura in viaturas)
            {
                MostraViatura(viatura);
            }

        }
    }
}

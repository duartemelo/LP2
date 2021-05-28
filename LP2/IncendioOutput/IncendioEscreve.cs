/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using System.Collections.Generic;
using IncendioBO;

namespace IncendioOutput
{
    /// <summary>
    /// Class / Library responsável pelos outputs dos incêndios
    /// </summary>
    public class IncendioEscreve
    {
        /// <summary>
        /// Mostra um incêndio
        /// </summary>
        /// <param name="i">Incêndio a mostrar</param>
        public static void MostraIncendio(Incendio i)
        {
            Console.WriteLine(i.ToString());
        }

        /// <summary>
        /// Mostra uma lista de incêndios
        /// </summary>
        /// <param name="incendios">Recebe a lista de incêndios para mostrar</param>
        public static void MostraIncendios(List<Incendio> incendios)
        {
            foreach(Incendio incendio in incendios)
            {
                MostraIncendio(incendio);
            }
        }


    }
}

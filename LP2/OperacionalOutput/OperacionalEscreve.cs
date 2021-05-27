using System;
using OperacionalBO;
using System.Collections.Generic;

namespace OperacionalOutput
{
    public class OperacionalEscreve
    {
        public static void MostraOperacional (Operacional o)
        {
            Console.WriteLine(o.ToString());
        }

        public static void MostraOperacionais (List<Operacional> operacionais)
        {
            foreach (Operacional operacional in operacionais)
            {
                MostraOperacional(operacional);
            }
        }
    }
}

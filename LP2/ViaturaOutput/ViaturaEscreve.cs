using System;
using System.Collections.Generic;
using ViaturaBO;

namespace ViaturaOutput
{
    public class ViaturaEscreve
    {
        public static void MostraViatura(Viatura v)
        {
            Console.WriteLine(v.ToString());
        }

        public static void MostraViaturas(List<Viatura> viaturas)
        {
            foreach (Viatura viatura in viaturas)
            {
                MostraViatura(viatura);
            }

        }
    }
}

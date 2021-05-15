using System;
using System.Collections.Generic;
using IncendioBO;

namespace IncendioOutput
{
    public class IncendioEscreve
    {
        public static void MostraIncendio(Incendio i)
        {
            Console.WriteLine(i.Id);
            Console.WriteLine(i.Tipo);
            Console.WriteLine(i.Coordenadas);
            Console.WriteLine(i.Estado);
        }

        public static void MostraIncendios(List<Incendio> incendios)
        {
            foreach(Incendio incendio in incendios)
            {
                MostraIncendio(incendio);
            }
        }
    }
}

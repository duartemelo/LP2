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
            incendios.CriarNovoIncendio("florestal", coordenadas);
            incendios.CriarNovoIncendio("urbano", coordenadas);

            incendios.EncontrarIncendioId(0).DefinirEstadoIncendio("inativo");

            incendios.MostrarIncendios();

            

            Console.ReadKey();
            
        }
    }
}

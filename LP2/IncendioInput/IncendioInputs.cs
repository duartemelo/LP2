﻿using System;
using IncendioBO;
using IncendioBR;

namespace IncendioInput
{
    public class IncendioInputs
    {
        public static bool CriarIncendio()
        {
            Incendio i1 = new Incendio();

            Console.WriteLine("Tipo de incêndio? Florestal ou urbano?");
            string tipo = Console.ReadLine();

            while (tipo.ToLower() != "florestal" && tipo.ToLower() != "urbano")
            {
                Console.WriteLine("Tipo de incêndio? Florestal ou urbano?");
                tipo = Console.ReadLine();
            }

            tipo.ToLower();
            if (tipo == "florestal")
                i1.Tipo = TipoIncendio.Florestal;
            else if (tipo == "urbano")
                i1.Tipo = TipoIncendio.Urbano;

            Console.WriteLine("Coordenadas X:");
            i1.Coordenadas[0] = float.Parse(Console.ReadLine());
            Console.WriteLine("Coordenadas Y:");
            i1.Coordenadas[1] = float.Parse(Console.ReadLine());

            Console.WriteLine("Estado do incêndio? Ativo ou extinto?");
            string estado = Console.ReadLine();

            while (estado.ToLower() != "ativo" && estado.ToLower() != "extinto")
            {
                Console.WriteLine("Estado do incêndio? Ativo ou extinto?");
                estado = Console.ReadLine();
            }

            Console.WriteLine("Data de inicio? dd/mm/yyyy hh:mm:ss");



            i1.InicioIncendio = DateTime.Parse(Console.ReadLine());
            if (estado.ToLower() == "ativo")
                i1.Estado = EstadoIncendio.Ativo;
            
            else if (estado.ToLower() == "extinto")
            {
                Console.WriteLine("Data de fim? dd/mm/yyyy hh:mm:ss");
                i1.FimIncendio = DateTime.Parse(Console.ReadLine());
                i1.Estado = EstadoIncendio.Extinto;
            }

            IncendioRegras.InsereIncendio(i1);



            return true;
        }
        public static bool AlterarHoraFimIncendio()
        {
            Console.WriteLine("ID incêndio: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Hora fim: ");
            DateTime horaFim = DateTime.Parse(Console.ReadLine());
            return IncendioRegras.AlterarHoraFimIncendio(id, horaFim);
        }

        public static bool RemoveIncendio()
        {
            Console.WriteLine("ID incêndio: ");
            int id = int.Parse(Console.ReadLine());
            return (IncendioRegras.RemoveIncendio(IncendioRegras.DevolveIncendioPeloId(id)));
        }
    }
}
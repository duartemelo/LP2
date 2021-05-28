using System;
using ViaturaBR;
using ViaturaBO;

namespace ViaturaInput
{
    public class ViaturaInputs
    {
        public static bool CriarViatura()
        {
            Viatura v1 = new Viatura();

            Console.WriteLine("Tipo viatura");
            string tipo = Console.ReadLine().ToLower();
            while (tipo != "mota" && tipo != "carro" && tipo != "helicoptero" && tipo != "aviao")
            {
                Console.WriteLine("Tipo viatura");
                tipo = Console.ReadLine().ToLower();
            }
            if (tipo == "mota")
                v1.TipoViatura = TipoViatura.Mota;
            else if (tipo == "carro")
                v1.TipoViatura = TipoViatura.Carro;
            else if (tipo == "helicoptero")
                v1.TipoViatura = TipoViatura.Helicoptero;
            else if (tipo == "aviao")
                v1.TipoViatura = TipoViatura.Aviao;

            Console.WriteLine("Matricula"); //aqui poderia manipular a string e ver se está com os traços nos devidos sítios
            v1.Matricula = Console.ReadLine();

            Console.WriteLine("Marca");
            v1.Marca = Console.ReadLine();

            Console.WriteLine("Modelo");
            v1.Modelo = Console.ReadLine();

            Console.WriteLine("Estado");
            string estado = Console.ReadLine().ToLower();
            while (estado != "ativo " && estado != "inativo")
            {
                Console.WriteLine("Estado");
                estado = Console.ReadLine().ToLower();
            }
            if (estado == "ativo")
                v1.EstadoViatura = EstadoViatura.Ativo;
            else if (estado == "inativo")
                v1.EstadoViatura = EstadoViatura.Inativo;

            return ViaturaRegras.InsereViatura(v1);
        }

        public static bool RemoveViatura()
        {
            Console.WriteLine("ID viatura: ");
            int idViatura = int.Parse(Console.ReadLine());
            return (ViaturaRegras.RemoveViatura(ViaturaRegras.DevolveViaturaPeloId(idViatura)));
        }
    }
}

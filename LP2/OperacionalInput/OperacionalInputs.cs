using System;
using OperacionalBO;
using OperacionalBR;

namespace OperacionalInput
{
    public class OperacionalInputs
    {
        public static bool CriarOperacional()
        {
            Operacional o1 = new Operacional();

            Console.WriteLine("CC");
            o1.Cc = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome");
            o1.Nome = Console.ReadLine();

            Console.WriteLine("Estado");
            string estado = Console.ReadLine().ToLower();
            while (estado != "ativo" && estado != "inativo")
            {
                Console.WriteLine("Estado");
                estado = Console.ReadLine().ToLower();
            }
            if (estado == "ativo")
                o1.Estado = EstadoOperacional.Ativo;
            else if (estado == "inativo")
                o1.Estado = EstadoOperacional.Inativo;

            Console.WriteLine("Data nasc (DD/MM/AAAA)");
            o1.DataNasc = DateTime.Parse(Console.ReadLine());

            return OperacionalRegras.InsereOperacional(o1);
        }

        public static bool RemoveOperacional()
        {
            Console.WriteLine("ID operacional: ");
            int id = int.Parse(Console.ReadLine());
            return (OperacionalRegras.RemoveOperacional(OperacionalRegras.DevolveOperacionalPeloId(id)));
        }

        public static bool AdicionarOperacionalACorp()
        {
            Console.WriteLine("ID operacional: ");
            int idOper = int.Parse(Console.ReadLine());

            Console.WriteLine("ID corporacacao: ");
            int idCorp = int.Parse(Console.ReadLine());

            return OperacionalRegras.AdicionarOperacionalACorporacao(idOper, idCorp);
        }

        

        public static bool AlterarCargoOper()
        {
            Console.WriteLine("ID operacional: ");
            int idOper = int.Parse(Console.ReadLine());
            Console.WriteLine("Novo cargo: ");
            string novoCargo = Console.ReadLine();
            return (OperacionalRegras.AlterarCargoOper(idOper, novoCargo));
        }

        public static bool AlterarSalarioOper()
        {
            Console.WriteLine("ID operacional: ");
            int idOper = int.Parse(Console.ReadLine());
            Console.WriteLine("Salario novo: ");
            float novoSalario = float.Parse(Console.ReadLine());

            return (OperacionalRegras.AlterarSalarioOper(idOper, novoSalario));
        }

        public static bool RemoveOperacionalDeCorp()
        {
            Console.WriteLine("ID operacional: ");
            int idOper = int.Parse(Console.ReadLine());
            return OperacionalRegras.RemoveOperacionalDeCorporacao(idOper);
        }


    }
}

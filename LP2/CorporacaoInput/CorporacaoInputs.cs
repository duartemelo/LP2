using System;
using CorporacaoBO;
using CorporacaoBR;

namespace CorporacaoInput
{
    public class CorporacaoInputs
    {
        public static bool CriarCorporacao()
        {
            Corporacao c1 = new Corporacao();

            Console.WriteLine("Freguesia: ");
            c1.Freguesia = Console.ReadLine();
            Console.WriteLine("Tipo: ");
            string tipo = Console.ReadLine();
            tipo = tipo.ToLower();
            while (tipo != "voluntarios" && tipo != "sapadores")
            {
                Console.WriteLine("Tipo: ");
                tipo = Console.ReadLine();
                tipo = tipo.ToLower();
            }
            if (tipo == "voluntarios")
                c1.Tipo = TipoCorp.Voluntarios;
            else if (tipo == "sapadores")
                c1.Tipo = TipoCorp.Sapadores;

            return CorporacaoRegras.InsereCorporacao(c1);
        }

        public static bool RemoveCorporacao()
        {
            Console.WriteLine("ID corporacao: "); //REMOVER TODOS OS BOMBEIROS DESTA CORP!!
            int id = int.Parse(Console.ReadLine());
            return (CorporacaoRegras.RemoveCorporacao(CorporacaoRegras.DevolveCorporacaoPeloId(id)));
        }
    }
}

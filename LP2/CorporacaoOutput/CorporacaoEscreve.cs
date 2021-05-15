using System;
using System.Collections.Generic;
using CorporacaoBO;

namespace CorporacaoOutput
{
    public class CorporacaoEscreve
    {
        public static void MostraCorporacao (Corporacao c)
        {
            Console.WriteLine(c.Id);
            Console.WriteLine(c.Tipo);
            Console.WriteLine(c.Freguesia);
        }

        public static void MostraCorporacoes(List<Corporacao> corporacoes)
        {
            foreach (Corporacao corporacao in corporacoes)
            {
                 MostraCorporacao(corporacao);
            }
            
        }

        

        
    }
}

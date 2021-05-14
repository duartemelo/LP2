using System;
using CorporacaoBO;
using CorporacaoData;

namespace CorporacaoBR
{
    public class CorporacaoRegras
    {
        public static bool InsereCorporacao(Corporacao c)
        {
            try
            {
                if (CorporacaoValidaParaInserir(c))
                    return CorporacaoDados.AddCorporacao(c);
                else
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static bool RemoveCorporacao(Corporacao c)
        {
            try
            {
                return CorporacaoDados.RemoveCorporacao(c);
            } catch (Exception e)
            {
                throw e;
            }
        }

        public static bool CorporacaoValidaParaInserir(Corporacao c)
        {
            if (c.Tipo != null && c.Freguesia != null)
            {
                return true;
            }
            return false;
        }

        public static void MostraCorporacoes()
        {
            CorporacaoDados.MostraCorporacoes();
        }
        


    }
}

using System;
using OperacionalBO;
using OperacionalData;
using GeneralOutputs;


namespace OperacionalBR
{
    public class OperacionalRegras
    {
        public static bool InsereOperacional(Operacional o)
        {
            try
            {
                if (OperacionalValidoParaInserir(o))
                {
                    return OperacionalDados.AddOperacional(o);
                }
                else
                {
                    GeneralEscreve.EscreveErro("Operacional não se encontra válido para inserir!"); //passar para exception?
                    return false;
                }
                    
                    
            } catch (Exception e)
            {
                throw e;
            }
        }

        public static bool RemoveOperacional (Operacional o)
        {
            try
            {
                return OperacionalDados.RemoveOperacional(o);
            } catch(Exception e)
            {
                throw e;
            }
        }

        public static bool OperacionalValidoParaInserir(Operacional o)
        {
            if (o != null || o.Nome != null)
                return true;
            return false;
        }

        public static void MostraOperacionais()
        {
            OperacionalDados.MostraOperacionais();
        }
    }
}

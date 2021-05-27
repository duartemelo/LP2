/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using ViaturaBO;
using ViaturaData;
using GeneralOutputs;

namespace ViaturaBR
{
    /// <summary>
    /// Regras de negócio relativas às viaturas
    /// </summary>
    public class ViaturaRegras
    {
        public static bool InsereViatura(Viatura v)
        {
            try
            {
                if (ViaturaValidaParaInserir(v))
                    return ViaturaDados.AddViatura(v);
                else
                {
                    GeneralEscreve.EscreveErro("Viatura não se encontra válida para inserir!"); //passar isto para exception?
                    return false;
                }
                    

            } catch (Exception e)
            {
                throw e;
            }
        }

        public static bool RemoveViatura(Viatura v)
        {
            try
            {
                return ViaturaDados.RemoveViatura(v);
            } catch (Exception e)
            {
                throw e;
            }
        }


        public static bool ViaturaValidaParaInserir(Viatura v)
        {
            if (v.Matricula != null || v != null)
                return true;
            return false;
        }

        public static void MostraViaturas()
        {
            ViaturaDados.MostraViaturas();
        }
    }
}

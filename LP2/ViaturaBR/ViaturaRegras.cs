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
        /// <summary>
        /// Insere uma viatura na lista de viaturas (presente no ViaturaData)
        /// </summary>
        /// <param name="v">Viatura a inserir</param>
        /// <returns>True se inseriu, False se não</returns>
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


        /// <summary>
        /// Remove uma viatura da lista de viaturas (presente em ViaturaData)
        /// </summary>
        /// <param name="v">Viatura a remover</param>
        /// <returns>True se removeu, False se não</returns>
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

        /// <summary>
        /// Verifica se uma viatura se encontra válida para inserir
        /// </summary>
        /// <param name="v">Viatura a verificar</param>
        /// <returns>True se está valida, False se está inválida</returns>
        public static bool ViaturaValidaParaInserir(Viatura v)
        {
            if (v.Matricula != null || v != null)
                return true;
            return false;
        }

        /// <summary>
        /// Mostra todas as viaturas
        /// </summary>
        public static void MostraViaturas()
        {
            ViaturaDados.MostraViaturas();
        }

        /// <summary>
        /// Devolve uma viatura (objeto) pelo seu id
        /// </summary>
        /// <param name="id">ID da viatura a devolver</param>
        /// <returns>Objeto viatura caso encontre, caso não encontre -> null</returns>
        public static Viatura DevolveViaturaPeloId(int id)
        {
            return ViaturaDados.DevolveViaturaPeloId(id);
        }
    }
}

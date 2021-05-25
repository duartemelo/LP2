/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using IncendioBO;
using IncendioData;
using GeneralOutputs;

namespace IncendioBR
{
    /// <summary>
    /// Regras de negócio relativas ao incêndio
    /// </summary>
    public class IncendioRegras
    {
        /// <summary>
        /// Insere um incendio nos incendios
        /// Verifica se o incêndio está válido para ser inserido e depois chama o método AddIncendio, presente na IncendioData (esta DLL, Regras, é a unica que consegue aceder à Data)
        /// </summary>
        /// <param name="i">Incendio a inserir</param>
        /// <returns>True se foi inserido, false se não foi inserido</returns>
        public static bool InsereIncendio(Incendio i)
        {
            try
            {
                if (IncendioValidoParaInserir(i))
                    return IncendioDados.AddIncendio(i);
                else
                    GeneralEscreve.EscreveErro("Incêndio não se encontra válido para inserir!");
                    return false;
                
            }catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Remove um incêndio da lista de incêndios
        /// Chama o método RemoveIncendio do IncendioDados, que consegue aceder à lista
        /// </summary>
        /// <param name="i">Incendio a remover</param>
        /// <returns>True se foi removido, False se não foi removido</returns>
        public static bool RemoveIncendio(Incendio i)
        {
            try
            {
                return IncendioDados.RemoveIncendio(i);
            }catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Verifica se um incêndio cumpre os requisitos para ser inserido
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool IncendioValidoParaInserir(Incendio i)
        {
            //testar como fica o Estado caso nao seja definido ao criar um incendio!
            if (i.Coordenadas != null || i != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Mostra a lista de incêndios
        /// Este procedimento tem de passar por esta library dado que é a única que consegue aceder ao IncendioDados - DLL que contem a lista.
        /// </summary>
        public static void MostraIncendios()
        {
            IncendioDados.MostraIncendios();
        }
    }
}

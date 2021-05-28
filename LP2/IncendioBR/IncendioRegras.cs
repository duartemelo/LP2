/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using IncendioBO;
using IncendioData;
using GeneralOutputs;
using OperacionalBR;
using ViaturaBR;

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

        public static Incendio DevolveIncendioPeloId(int idIncendio)
        {
            return (IncendioDados.DevolveIncendioPeloId(idIncendio));
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

        /// <summary>
        /// Verifica se um determinado ID de um operacional existe em algum incêndio
        /// </summary>
        /// <param name="id">ID do operacional</param>
        /// <returns>True se existir em algum incêndio, False se não existir em nenhum incêndio</returns>
        public static bool VerificaOperacionalIncendios(int id)
        {
            return IncendioDados.VerificaOperacionalIncendios(id);
        }

        /// <summary>
        /// Adiciona um operacional a um incêndio a partir do id do incêndio e do id do operacional
        /// </summary>
        /// <param name="idIncendio">ID incêndio onde vai adicionar o operacional</param>
        /// <param name="idOper">ID do operacional a adicionar ao incêndio</param>
        /// <returns></returns>
        public static bool AdicionarOperacionalIncendio(int idOper, int idIncendio)
        {
            //operacional tem de existir!
            if (OperacionalRegras.VerificaSeOperacionalExiste(idOper))
            {
                //operacional tem de estar ativo!
                if (OperacionalRegras.DevolveOperacionalPeloId(idOper).Estado == OperacionalBO.EstadoOperacional.Ativo)
                {
                    //nao pode estar em nenhum incendio!
                    if (VerificaOperacionalIncendios(idOper) != true)
                    {
                        //adiciona operacional
                        return IncendioDados.AdicionaOperacionalIncendioID(idOper, idIncendio);
                    }
                }

                
            }
            return false;
        }

        public static bool RemoveOperacionalIncendio(int idOper, int idIncendio)
        {
            return (IncendioDados.RemoveOperacionalIncendioID(idOper, idIncendio));
        }

        public static bool AlterarHoraFimIncendio(int idIncendio, DateTime horaFim)
        {
            return (IncendioDados.AlterarHoraFimIncendio(idIncendio, horaFim));
        }

       

        public static bool AdicionarViaturaAIncendio(int idViatura, int idIncendio)
        {
            //existe!
            if (ViaturaRegras.DevolveViaturaPeloId(idViatura) != null)
            {
                //nao esta em nenhum incendio!
                if (IncendioDados.VerificaViaturaIncendios(idViatura) != true)
                {
                    return (IncendioDados.AdicionarViaturaIncendio(idViatura, idIncendio));
                }
            }
            return false;
        }



    }
}

/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using System;
using OperacionalBO;
using OperacionalData;
using GeneralOutputs;
using CorporacaoBR;


namespace OperacionalBR
{
    /// <summary>
    /// Regras de negócio relativas ao objeto Operacional
    /// </summary>
    public class OperacionalRegras
    {
        /// <summary>
        /// Inserir um operacional na lista de operacionais (presente em OperacionalData)
        /// </summary>
        /// <param name="o">Operacional a adicionar</param>
        /// <returns>True se adicionou, False se não adicionou</returns>
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

        /// <summary>
        /// Remove operacional da lista de operacionais (presente em OperacionalDados)
        /// </summary>
        /// <param name="o">Operacional a remover</param>
        /// <returns>True se removeu, False se não removeu</returns>
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

        /// <summary>
        /// Verifica se um objeto operacional está valido para adicionar
        /// </summary>
        /// <param name="o">Operacional a verificar</param>
        /// <returns>True se está valido, false se está inválido</returns>
        public static bool OperacionalValidoParaInserir(Operacional o)
        {
            if (o != null || o.Nome != null)
                return true;
            return false;
        }

        /// <summary>
        /// Mostra lista de operacionais
        /// </summary>
        public static void MostraOperacionais()
        {
            OperacionalDados.MostraOperacionais();
        }

        /// <summary>
        /// Verifica se um operacional existe na lista de operacionais a partir do seu ID (presente em OperacionalData)
        /// </summary>
        /// <param name="id">ID do operacional a verificar</param>
        /// <returns>True se existe, False se não existe</returns>
        public static bool VerificaSeOperacionalExiste(int id)
        {
            return OperacionalDados.VerificaSeOperacionalExiste(id);
        }

        /// <summary>
        /// Adicionar um operacional a uma corporação, pelo id de ambos
        /// </summary>
        /// <param name="idOper">ID do operacional a adicionar</param>
        /// <param name="idCorp">ID da corporação</param>
        /// <returns>True se adicionou, False se não adicionou</returns>
        public static bool AdicionarOperacionalACorporacao(int idOper, int idCorp)
        {
            if (CorporacaoRegras.VerificarCorporacaoExiste(idCorp))
            {
                return(OperacionalDados.AdicionarOperacionalACorporacao(idOper, idCorp));
            }
            return false;
        }

        /// <summary>
        /// Remove operacional de uma/qualquer corporação (fica a 0, dado que ID nao pode ser null)
        /// </summary>
        /// <param name="idOper">ID do operacional</param>
        /// <returns>True se removeu, False se não</returns>
        public static bool RemoveOperacionalDeCorporacao(int idOper)
        {
            return OperacionalDados.RemoveOperacionalDeCorporacao(idOper);
        }

        /// <summary>
        /// Devolve um objeto operacional pelo seu ID
        /// </summary>
        /// <param name="idOper">ID operacional a devolver</param>
        /// <returns>Operacional objeto, ou nulo se não encontrou</returns>
        public static Operacional DevolveOperacionalPeloId(int idOper)
        {
            return (OperacionalDados.DevolveOperacionalPeloId(idOper));
        }

        /// <summary>
        /// Altera o cargo de um operacional
        /// </summary>
        /// <param name="idOper">ID operacional</param>
        /// <param name="novoCargo">Novo cargo</param>
        /// <returns>True se alterou, False se não</returns>
        public static bool AlterarCargoOper(int idOper, string novoCargo)
        {
            return (OperacionalDados.AlterarCargoOper(idOper, novoCargo));
        }

        /// <summary>
        /// Altera o salário de um operacional
        /// </summary>
        /// <param name="idOper">ID operacional</param>
        /// <param name="novoSalario">Novo salário</param>
        /// <returns>True se alterou, False se não</returns>
        public static bool AlterarSalarioOper(int idOper, float novoSalario)
        {
            return (OperacionalDados.AlterarSalarioOper(idOper, novoSalario));
        }

        /// <summary>
        /// Inativa um operacional
        /// </summary>
        /// <param name="idOper">ID do operacional a inativar</param>
        /// <returns>True se inativou um operacional, False se não</returns>
        public static bool InativarOper(int idOper)
        {
            return (OperacionalDados.InativarOper(idOper));
        }
    }
}

/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using OperacionalBO;
using OperacionalOutput;
using System.Collections.Generic;

namespace OperacionalData
{
    public class OperacionalDados
    {
        #region Attributes

        private static int numOperacionais = 0;
        private static int numIDs = 1;
        private static List<Operacional> operacionais = new List<Operacional>();

        #endregion

        #region Properties

        public static int NumOperacionais
        {
            get => numOperacionais;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adicionar um operacional à lista de operacionais
        /// </summary>
        /// <param name="o">Operacional a adicionar</param>
        /// <returns>True se adicionou, False se não</returns>
        public static bool AddOperacional(Operacional o)
        {
            if (VerificaSeOperacionalExiste(o))
                return false;
            o.Id = numIDs;
            operacionais.Add(o);
            numOperacionais++;
            numIDs++;
            return true;
        }

        /// <summary>
        /// Remove um operacional da lista de operacionais
        /// </summary>
        /// <param name="o">Operacional a remover</param>
        /// <returns>True se removeu, False se não</returns>
        public static bool RemoveOperacional(Operacional o)
        {
            if (operacionais.Remove(o))
            {
                numOperacionais--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica se um operacional existe na lista de operacionais
        /// </summary>
        /// <param name="o">Operacional a confirmar</param>
        /// <returns>True se existe, False se não</returns>
        public static bool VerificaSeOperacionalExiste(Operacional o)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional == o)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica se um operacional existe na lista de operacionais, pelo seu ID
        /// </summary>
        /// <param name="id">ID operacional</param>
        /// <returns>True se existe, False se não</returns>
        public static bool VerificaSeOperacionalExiste(int id)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == id)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Mostra todos os operacionais
        /// </summary>
        public static void MostraOperacionais()
        {
            OperacionalEscreve.MostraOperacionais(operacionais);
        }

        /// <summary>
        /// Adiciona um operacional a uma corporação
        /// </summary>
        /// <param name="idOper">ID operacional</param>
        /// <param name="idCorp">ID corporação</param>
        /// <returns>True se adicionou, False se não</returns>
        public static bool AdicionarOperacionalACorporacao(int idOper, int idCorp)
        {
            foreach(Operacional operacional in operacionais)
            {
                if(operacional.Id == idOper)
                {
                    if (operacional.Estado == EstadoOperacional.Ativo)
                    {
                        operacional.CorporacaoID = idCorp;
                        return true;
                    }
                    
                }
            }
            return false;


            
        }

        /// <summary>
        /// Devolve operacional pelo ID (objeto!)
        /// </summary>
        /// <param name="idOper">ID operacional a devolver</param>
        /// <returns>Operacional objeto se encontrar, null se não encontrar</returns>
        public static Operacional DevolveOperacionalPeloId(int idOper)
        {
            foreach(Operacional operacional in operacionais)
            {
                if(operacional.Id == idOper)
                {
                    return operacional;
                }
            }
            return null;
        }

        /// <summary>
        /// Remove um operacional de uma/qualquer corporação
        /// </summary>
        /// <param name="idOper">ID operacional</param>
        /// <returns>True se removeu, False se não removeu</returns>
        public static bool RemoveOperacionalDeCorporacao(int idOper)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == idOper)
                {
                    operacional.CorporacaoID = 0;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Altera o cargo de um operacional
        /// </summary>
        /// <param name="idOper">ID operacional</param>
        /// <param name="novoCargo">Novo Cargo</param>
        /// <returns>True se alterou, False se não</returns>
        public static bool AlterarCargoOper(int idOper, string novoCargo)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == idOper)
                {
                    operacional.Cargo = novoCargo;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Altera o salário de um operacional
        /// </summary>
        /// <param name="idOper">ID operacional</param>
        /// <param name="novoSalario">Novo salário</param>
        /// <returns></returns>
        public static bool AlterarSalarioOper(int idOper, float novoSalario)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == idOper)
                {
                    if (operacional.Estado == EstadoOperacional.Ativo)
                    {
                        if (operacional.CorporacaoID != 0)
                        {
                            operacional.Salario = novoSalario;
                            return true;
                        }
                    }
                    
                }
            }
            return false;
        }

        /// <summary>
        /// Inativa um operacional
        /// </summary>
        /// <param name="idOper">ID operacional</param>
        /// <returns>True se inativou, False se não</returns>
        public static bool InativarOper(int idOper)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == idOper)
                {
                    operacional.Estado = EstadoOperacional.Inativo;
                    operacional.CorporacaoID = 0;
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}

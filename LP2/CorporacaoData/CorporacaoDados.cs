/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using CorporacaoBO;
using CorporacaoOutput;
using System.Collections.Generic;

namespace CorporacaoData
{
    /// <summary>
    /// Library que trata de guardar as corporações, apenas é acedida pelo CorporacaoBR (CorporacaoRegras)
    /// </summary>
    public class CorporacaoDados
    {
        #region Attributes

        private static int numCorporacoes = 0;        
        private static int numIDs = numCorporacoes; //criado apenas para evitar conflitos com IDs repetidos, quando é criada uma corp, o numID é incrementado, quando é removida, o numID mantem-se
        private static List<Corporacao> corporacoes = new List<Corporacao>();


        #endregion

        #region Constructors

        #endregion

        #region Properties

        public static int NumCorporacoes
        {
            get => numCorporacoes;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adiciona uma corporação à lista de corporações
        /// Para evitar corporações repetidas (mesmo tipo e mesma freguesia), antes de adicionar é feita essa verificação (se já existe uma igual)
        /// </summary>
        /// <param name="c">Corporacação a adicionar</param>
        /// <returns>Falso se não for adicionado, True se for adicionado</returns>
        public static bool AddCorporacao(Corporacao c) 
        {
            if (VerificarCorporacaoExiste(c))
                //mensagem de erro (repetida) ?
                return false;
            c.Id = numIDs;
            corporacoes.Add(c);
            numCorporacoes++;
            numIDs++;
            return true;
            
        }

        /// <summary>
        /// Remove uma corporação das corporações
        /// </summary>
        /// <param name="c"></param>
        /// <returns>True se for removida com sucesso, False se não for removida com sucesso (não existia a corp., por exemplo)</returns>
        public static bool RemoveCorporacao (Corporacao c)
        {
            if (corporacoes.Remove(c))
            {
                numCorporacoes--;
                return true;
            }
            else
                return false;
            
        }

        /// <summary>
        /// Verifica se uma corporação já existe (pelo tipo e freguesia, para evitar repetidos)
        /// </summary>
        /// <param name="tipo">Tipo de corporação a verificar</param>
        /// <param name="freguesia">Tipo de freguesia a verificar</param>
        /// <returns>True se já existir, False se não existir</returns>
        public static bool VerificarCorporacaoExiste(Corporacao c)
        {
            foreach (Corporacao corporacao in corporacoes)
            {
                if (c == corporacao)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Devolve uma corporação presente nas corporações pelo seu ID
        /// </summary>
        /// <param name="id">ID a procurar</param>
        /// <returns>Retorna a corporação se a encontrar, ou null se não encontrar nada</returns>
        public static Corporacao ObterCorporacaoPeloId(int id)
        {
            foreach(Corporacao corporacao in corporacoes)
            {
                if (corporacao.Id == id)
                    return corporacao;
            }
            return null;
        }

        /// <summary>
        /// Devolve o num de corporações de um determinado tipo
        /// </summary>
        /// <param name="tipo">Tipo de corporação a procurar</param>
        /// <returns>Núm de corporações do tipo recebido como argumento</returns>
        public static int NumeroCorporacoesPorTipo(TipoCorp tipo)
        {
            int corporacoesPorTipo = 0;
            foreach(Corporacao corporacao in corporacoes)
            {
                if (corporacao.Tipo == tipo)
                {
                    corporacoesPorTipo++;
                }
            }

            return corporacoesPorTipo;
        }

        /// <summary>
        /// Mostra todas as corporações, este método tem de estar nesta library dado que é necessário passar a lista como parâmetro para o output
        /// </summary>
        public static void MostraCorporacoes()
        {
            CorporacaoEscreve.MostraCorporacoes(corporacoes);
        }

        #endregion
    }
}

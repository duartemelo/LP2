/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using CorporacaoBO;
using CorporacaoData;
using GeneralOutputs;

namespace CorporacaoBR
{
    /// <summary>
    /// Regras de negócio relativas à corporação / corporações
    /// </summary>
    public class CorporacaoRegras
    {
        /// <summary>
        /// Insere uma corporação às corporações
        /// Verifica se a corporação está válida para ser inserida e depois chama o método AddCorporacao, presente na CorporacaoData (esta DLL, CorporacaoRegras, é a unica que consegue aceder à CorporacaoData)
        /// </summary>
        /// <param name="c">Corporação</param>
        /// <returns>True se for inserido, False se não for inserido</returns>
        public static bool InsereCorporacao(Corporacao c)
        {
            try
            {
                if (CorporacaoValidaParaInserir(c))
                    return CorporacaoDados.AddCorporacao(c);
                else
                    GeneralEscreve.EscreveErro("Corporação não se encontra válida para inserir!");
                    return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Remove uma corporação das corporações, chama o método RemoveCorporação presente no CorporacaoData
        /// </summary>
        /// <param name="c">Corporação</param>
        /// <returns>True se for removido, False se não for removido</returns>
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

        /// <summary>
        /// Função que retorna true se a corporação estiver válida para inserir, ou false caso não esteja válida para inserir
        /// Para estar valida, o tipo tem de estar definido e a freguesia também
        /// </summary>
        /// <param name="c">Corporação</param>
        /// <returns>True se estiver válida para inserir, False se não estiver válida para inserir</returns>
        public static bool CorporacaoValidaParaInserir(Corporacao c)
        {
            if (c.Freguesia != null || c != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Mostra corporações, este método está aqui dado que, para aceder às corporações, é necessário aceder ao CorporacaoData, e como esta library serve de "ponte" para os dados, é necessário "passar" por aqui
        /// </summary>
        public static void MostraCorporacoes()
        {
            CorporacaoDados.MostraCorporacoes();
        }
        
        /// <summary>
        /// Verifica se uma corporação existe na lista de corporações a partir do seu ID
        /// </summary>
        /// <param name="id">ID da corporação a confirmar</param>
        /// <returns>Retorna o que a função chamada do data retornar.</returns>
        public static bool VerificarCorporacaoExiste(int id)
        {
            return CorporacaoDados.VerificarCorporacaoExiste(id);
        }

        /// <summary>
        /// Devolve a corporação a partir do seu ID (cuidado! não manipular este objeto, pois não é alterado na lista!)
        /// </summary>
        /// <param name="id">ID Corporação</param>
        /// <returns>Corporaçao (objeto)</returns>
        public static Corporacao DevolveCorporacaoPeloId(int id)
        {
            return CorporacaoDados.ObterCorporacaoPeloId(id);
        }


    }
}

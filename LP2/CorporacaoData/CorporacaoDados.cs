/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CorporacaoBO;
using CorporacaoOutput;
using System.Collections.Generic;

namespace CorporacaoData
{
    /// <summary>
    /// Library que trata de guardar as corporações, apenas é acedida pelo CorporacaoBR (CorporacaoRegras)
    /// </summary>
    [Serializable]
    public class CorporacaoDados
    {
        #region Attributes

        private static int numCorporacoes = 0;        
        private static int numIDs = 1; //criado apenas para evitar conflitos com IDs repetidos, quando é criada uma corp, o numID é incrementado, quando é removida, o numID mantem-se
        private static List<Corporacao> corporacoes = new List<Corporacao>();


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
        /// Verifica se uma corporação existe na lista de corporações
        /// </summary>
        /// <param name="id">ID corporação a confirmar</param>
        /// <returns>True se existe, False se não existe</returns>
        public static bool VerificarCorporacaoExiste(int id)
        {
            foreach(Corporacao corporacao in corporacoes)
            {
                if (corporacao.Id == id)
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

        #region Data Saving

        /// <summary>
        /// Escreve a lista de corporações num ficheiro binário
        /// </summary>
        public static void CorporacoesEscreverFicheiro()
        {
            FileStream file = new FileStream("CorporacoesData.bin", FileMode.Create);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, corporacoes);

            file.Close();
        }

        /// <summary>
        /// Escreve o numIDs num ficheiro binário
        /// </summary>
        public static void NumIDsEscreverFicheiro()
        {
            FileStream file = new FileStream("NumIDsCorporacoesData.bin", FileMode.Create);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, numIDs);

            file.Close();
        }
        #endregion

        #region Loading Data

        /// <summary>
        /// Lê a lista de corporações de um ficheiro binário
        /// </summary>
        public static void CorporacoesLerFicheiro()
        {
            Stream file = File.Open("CorporacoesData.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
            {
                corporacoes = (List<Corporacao>)b.Deserialize(file);
                numCorporacoes = corporacoes.Count;
            }

            file.Close();
        }

        /// <summary>
        /// Lê o numIDs a partir de um ficheiro binario
        /// </summary>
        public static void NumIDsLerFicheiro()
        {
            Stream file = File.Open("NumIDsCorporacoesData.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                numIDs = (int)b.Deserialize(file);

            file.Close();
        }


        #endregion
    }
}

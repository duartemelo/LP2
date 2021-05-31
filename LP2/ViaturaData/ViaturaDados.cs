/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using ViaturaBO;
using ViaturaOutput;

namespace ViaturaData
{
    /// <summary>
    /// Library / class que trata de guardar as viaturas, apenas é acedida pelo ViaturaBR (ViaturaRegras)
    /// </summary>
    [Serializable]
    public class ViaturaDados
    {
        #region Attributes
        private static int numViaturas = 0;
        private static int numIDs = 1;
        private static List<Viatura> viaturas = new List<Viatura>();

        #endregion

        #region Properties

        /// <summary>
        /// Poderá ser útil para devolver o número de viaturas totais
        /// Não existe set pois o numViaturas apenas é alterado dentro da classe!
        /// </summary>
        public static int NumViaturas
        {
            get => numViaturas;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adiciona uma viatura à lista de viaturas
        /// Verifica se viatura já existe (usa operador definido ==, que confirma se a matrícula é igual)
        /// </summary>
        /// <param name="v">Viatura a adicionar</param>
        /// <returns>True se adicionou, False se não adicionou</returns>
        public static bool AddViatura(Viatura v) 
        {
            if (VerificaViaturaExiste(v))
                return false;
            v.Id = numIDs;
            viaturas.Add(v);
            numViaturas++;
            numIDs++;
            return true;
        
        }

        /// <summary>
        /// Remove uma viatura da lista de viaturas
        /// </summary>
        /// <param name="v">Viatura a remover</param>
        /// <returns>True caso seja removida, False caso não seja removida</returns>
        public static bool RemoveViatura(Viatura v) 
        {
            if (viaturas.Remove(v))
            {
                numViaturas--;
                return true;
            }
            else
                return false;
        
        }
        
        /// <summary>
        /// Verifica se uma viatura existe
        /// Utiliza o == definido no ViaturaBO, que verifica se a matrícula é igual
        /// </summary>
        /// <param name="v">Viatura a verificar</param>
        /// <returns>True se existir, False se não existir</returns>
        public static bool VerificaViaturaExiste(Viatura v) 
        {
            foreach(Viatura viatura in viaturas)
            {
                if (viatura == v)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Mostra a lista de viaturas
        /// Utiliza o método MostraViaturas da library ViaturaOutput, passando como parâmetro a lista de viaturas
        /// </summary>
        public static void MostraViaturas()
        {
            ViaturaEscreve.MostraViaturas(viaturas);  
        }

        /// <summary>
        /// Devolve uma viatura (objeto) pelo seu id
        /// </summary>
        /// <param name="id">ID da viatura a devolver</param>
        /// <returns>Objeto viatura se encontrar, null se não encontrar</returns>
        public static Viatura DevolveViaturaPeloId(int id)
        {
            foreach(Viatura viatura in viaturas)
            {
                if (viatura.Id == id)
                {
                    return viatura;
                }
            }
            return null;
        }

        #endregion

        #region Data Saving

        /// <summary>
        /// Escreve a lista de viaturas num ficheiro binário
        /// </summary>
        public static void ViaturasEscreverFicheiro()
        {
            FileStream file = new FileStream("ViaturasData.bin", FileMode.Create);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, viaturas);

            file.Close();
        }

        /// <summary>
        /// Escreve o numIDs num ficheiro binário
        /// </summary>
        public static void NumIDsEscreverFicheiro()
        {
            FileStream file = new FileStream("NumIDsViaturasData.bin", FileMode.Create);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, numIDs);

            file.Close();
        }
        #endregion

        #region Loading Data

        /// <summary>
        /// Lê a lista de viaturas de um ficheiro binário
        /// </summary>
        public static void ViaturasLerFicheiro()
        {
            Stream file = File.Open("ViaturasData.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
            {
                viaturas = (List<Viatura>)b.Deserialize(file);
                numViaturas = viaturas.Count;
            }

            file.Close();
        }

        /// <summary>
        /// Lê o numIDs a partir de um ficheiro binario
        /// </summary>
        public static void NumIDsLerFicheiro()
        {
            Stream file = File.Open("NumIDsViaturasData.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                numIDs = (int)b.Deserialize(file);

            file.Close();
        }


        #endregion
    }
}

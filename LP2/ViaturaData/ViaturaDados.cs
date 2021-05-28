/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using System.Collections.Generic;
using ViaturaBO;
using ViaturaOutput;

namespace ViaturaData
{
    /// <summary>
    /// Library / class que trata de guardas as viaturas, apenas é acedida pelo ViaturaBR (ViaturaRegras)
    /// </summary>
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
    }
}

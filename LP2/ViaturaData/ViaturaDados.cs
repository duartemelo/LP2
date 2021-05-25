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
        private static int numIDs = numViaturas;
        private static List<Viatura> viaturas = new List<Viatura>();

        #endregion

        #region Constructors

        #endregion

        #region Properties

        public static int NumViaturas
        {
            get => numViaturas;
        }

        #endregion

        #region Methods

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
        
        public static bool VerificaViaturaExiste(Viatura v) 
        {
            foreach(Viatura viatura in viaturas)
            {
                if (viatura == v)
                    return true;
            }
            return false;
        }

        public static void MostraViaturas()
        {
            ViaturaEscreve.MostraViaturas(viaturas);  
        }

        #endregion
    }
}

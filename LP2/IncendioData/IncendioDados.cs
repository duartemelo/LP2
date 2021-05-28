/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using IncendioBO;
using IncendioOutput;
using System.Collections.Generic;

namespace IncendioData
{
    /// <summary>
    /// Library que trata de guardar os incêndios, apenas é acedida pelo IncendioBR (IncendioRegras)
    /// </summary>
    public class IncendioDados
    {
        #region Attributes
        private static int numIncendios = 0;
        private static int numIDs = 1;
        private static List<Incendio> incendios = new List<Incendio>();

        #endregion

        

        #region Properties

        public static int NumIncendios
        {
            get => numIncendios;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adiciona um incêndio à lista de incêndios
        /// Verifica se o incêndio já existe
        /// </summary>
        /// <param name="i">Incêndio a adicionar</param>
        /// <returns>True caso seja adicionado, False caso não seja adicionado</returns>
        public static bool AddIncendio(Incendio i)
        {
            if (VerificaSeIncendioExiste(i))
            {
                return false;
            }
            
            i.Id = numIDs;
            incendios.Add(i);
            numIncendios++;
            numIDs++;
            return true;
        }

        /// <summary>
        /// Remove um incêndio da lista de incêndios
        /// </summary>
        /// <param name="i">Incêndio a remover</param>
        /// <returns>True caso seja removido, False caso não seja removido</returns>
        public static bool RemoveIncendio(Incendio i)
        {
            if (incendios.Remove(i))
            {
                numIncendios--;
                return true;
            }
                return false;
        }

        /// <summary>
        /// Devolve o número de incêndios por estado
        /// </summary>
        /// <param name="estado">Estado a procurar</param>
        /// <returns>Numero de incêndios do estado procurado</returns>
        public static int NumeroIncendiosPorEstado(EstadoIncendio estado)
        {
            int incendiosEstado = 0;
            foreach (Incendio incendio in incendios)
            {
                if (incendio.Estado == estado)
                    incendiosEstado++;
            }
            return incendiosEstado;
        }





        /// <summary>
        /// Verifica se um incêndio já existe
        /// </summary>
        /// <param name="i">Incêndio a verificar</param>
        /// <returns>True se já existe, false se não existe</returns>
        public static bool VerificaSeIncendioExiste(Incendio i)
        {
            foreach(Incendio incendio in incendios)
            {
                if (incendio == i)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Mostra todos os incêndios, este método tem de estar nesta library dado que é necessário passar a lista como parâmetro para o output
        /// </summary>
        public static void MostraIncendios()
        {
            IncendioEscreve.MostraIncendios(incendios);
        }

        /// <summary>
        /// Verifica se um determinado ID de um operacional existe em algum incêndio
        /// </summary>
        /// <param name="id">ID do operacional a procurar</param>
        /// <returns>True se existir, False se não existir</returns>
        public static bool VerificaOperacionalIncendios(int id)
        {
            bool existe = false;
            foreach(Incendio incendio in incendios)
            {
                existe = incendio.VerificarOperacionalExisteNoIncendio(id);
            }
            return existe;
        }

        /// <summary>
        /// Adiciona um operacional a um incêndio pelos IDs de ambos
        /// </summary>
        /// <param name="idIncendio"></param>
        /// <param name="idOper"></param>
        /// <returns>True se adicionou, False se não existiu</returns>
        public static bool AdicionaOperacionalIncendioID(int idOper, int idIncendio)
        {
            foreach(Incendio incendio in incendios)
            {
                if (incendio.Id == idIncendio)
                {
                    incendio.AdicionarOperacional(idOper);
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}

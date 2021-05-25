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
        private static int numIDs = numIncendios;
        private static List<Incendio> incendios = new List<Incendio>();

        #endregion

        #region Constructors
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
        /// Verifica se o incêndio pode ser adicionado (evitar conflitos de vários ativos no mesmo sítio, mas permitir que se adicione um extinto "por cima" de um ativo -> para permitir adicionar um incêndio que já decorreu naquele local, enquanto um está ativo naquele mesmo sítio
        /// </summary>
        /// <param name="i">Incêndio a adicionar</param>
        /// <returns>True caso seja adicionado, False caso não seja adicionado</returns>
        public static bool AddIncendio(Incendio i)
        {
            if (VerificaSeIncendioExiste(i) == true)
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
            else
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

        #endregion
    }
}

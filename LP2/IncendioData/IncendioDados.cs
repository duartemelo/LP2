/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using IncendioBO;
using IncendioOutput;
using System.Collections.Generic;

namespace IncendioData
{
    /// <summary>
    /// Library que trata de guardar os incêndios, apenas é acedida pelo IncendioBR (IncendioRegras)
    /// </summary>
    [Serializable]
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
                    return(incendio.AdicionarOperacional(idOper));
                    
                }
            }
            return false;
        }

        /// <summary>
        /// Remove operacional de um incêndio, a partir dos ID de ambos
        /// </summary>
        /// <param name="idOper">ID operacional</param>
        /// <param name="idIncendio">ID incendio</param>
        /// <returns>True se removeu, False se não</returns>
        public static bool RemoveOperacionalIncendioID(int idOper, int idIncendio)
        {
            foreach(Incendio incendio in incendios)
            {
                if (incendio.Id == idIncendio)
                {
                    return (incendio.RemoverOperacional(idOper));
                }
            }
            return false;
        }

        /// <summary>
        /// Altera a hora de fim de um incêndio
        /// </summary>
        /// <param name="idIncendio">ID incendio a alterar</param>
        /// <param name="fimIncendio">Hora de fim</param>
        /// <returns>True se alterou, False se não</returns>
        public static bool AlterarHoraFimIncendio(int idIncendio, DateTime fimIncendio)
        {
            foreach(Incendio incendio in incendios)
            {
                if (incendio.Id == idIncendio)
                {
                    if (fimIncendio > incendio.InicioIncendio && fimIncendio <= DateTime.Today)
                    {
                        incendio.FimIncendio = fimIncendio;
                        incendio.Estado = EstadoIncendio.Extinto;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Devolve um objeto incêndio a partir do seu ID
        /// </summary>
        /// <param name="idIncendio">ID do incêndio a procurar</param>
        /// <returns>Obj incêndio, se existir. Caso não exista, retorna null</returns>
        public static Incendio DevolveIncendioPeloId(int idIncendio)
        {
            foreach(Incendio incendio in incendios)
            {
                if (incendio.Id == idIncendio)
                {
                    return incendio;
                }
            }
            return null;
        }

        /// <summary>
        /// Verifica se uma viatura está em algum incêndio
        /// </summary>
        /// <param name="id">ID viatura</param>
        /// <returns>True se existe em algum incêndio, False caso não exista</returns>
        public static bool VerificaViaturaIncendios(int id)
        {
            bool existe = false;
            foreach (Incendio incendio in incendios)
            {
                existe = incendio.VerificarViaturaExisteNoIncendio(id);
            }
            return existe;
        }

        /// <summary>
        /// Adiciona uma viatura a um incêndio
        /// </summary>
        /// <param name="idViatura">id da viatura a adicionar</param>
        /// <param name="idIncendio">id do incendio a adicionar</param>
        /// <returns></returns>
        public static bool AdicionarViaturaIncendio(int idViatura, int idIncendio)
        {
            foreach(Incendio incendio in incendios)
            {
                if (incendio.Id == idIncendio)
                {
                    return(incendio.AdicionarViatura(idViatura));
                }
            }
            return false;
        }

        #endregion

        #region Data Saving

        /// <summary>
        /// Escreve a lista de incêndios num ficheiro binário
        /// </summary>
        public static void IncendiosEscreverFicheiro()
        {
            FileStream file = new FileStream("IncendiosData.bin", FileMode.Create);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, incendios);

            file.Close();
        }

        /// <summary>
        /// Escreve o numIDs num ficheiro binário
        /// </summary>
        public static void NumIDsEscreverFicheiro()
        {
            FileStream file = new FileStream("NumIDsIncendiosData.bin", FileMode.Create);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, numIDs);

            file.Close();
        }
        #endregion

        #region Loading Data

        /// <summary>
        /// Lê a lista de incêndios de um ficheiro binário
        /// </summary>
        public static void IncendiosLerFicheiro()
        {
            Stream file = File.Open("IncendiosData.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
            {
                incendios = (List<Incendio>)b.Deserialize(file);
                numIncendios = incendios.Count;
            }

            file.Close();
        }

        /// <summary>
        /// Lê o numIDs a partir de um ficheiro binario
        /// </summary>
        public static void NumIDsLerFicheiro()
        {
            Stream file = File.Open("NumIDsIncendiosData.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                numIDs = (int)b.Deserialize(file);

            file.Close();
        }


        #endregion
    }
}

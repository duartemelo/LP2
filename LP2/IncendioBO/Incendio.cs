/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using System.Collections.Generic;

namespace IncendioBO
{
    public enum EstadoIncendio
    {
        Extinto,
        Ativo
    }
    public enum TipoIncendio
    {
        Florestal,
        Urbano
    }
    /// <summary>
    /// Class incêndio -> esta class apenas é responsável pela criação do objeto, devolver e alterar dados do mesmo.
    /// </summary>
    public class Incendio
    {
       
        #region Attributes

        private int id;
        private TipoIncendio tipo;
        private float[] coordenadas;
        private EstadoIncendio estado;
        DateTime inicioIncendio;
        DateTime fimIncendio;
        private List<int> operacionaisIDs;
        private List<int> viaturasIDs;


        #endregion

        #region Constructors

        /// <summary>
        /// Cria as listas pertencentes a cada objeto incêndio
        /// </summary>
        public Incendio()
        {
            operacionaisIDs = new List<int>();
            viaturasIDs = new List<int>();
            //estado default = ativo?
        }

        #endregion

        #region Properties

        public int Id
        {
            get => id;
            set => id = value;
        }


        public TipoIncendio Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        public float[] Coordenadas
        {
            get => coordenadas;
            set => coordenadas = value;
        }

        public EstadoIncendio Estado
        {
            get => estado;
            set => estado = value;
        }

        public DateTime InicioIncendio
        {
            get => inicioIncendio;
            set => inicioIncendio = value;
        }

        public DateTime FimIncendio
        {
            get => fimIncendio;
            set => fimIncendio = value;
        }

        #endregion

        #region Overrides, Operators

        public static bool operator ==(Incendio i1, Incendio i2)
        {
            return (i1.Coordenadas == i2.coordenadas && i1.Tipo == i2.Tipo);
        }

        public static bool operator !=(Incendio i1, Incendio i2)
        {
            return !(i1 == i2);
        }

        public override bool Equals(object obj)
        {
            return this == (Incendio)obj;
        }

        public override string ToString()
        {   
            return string.Format("ID: {0}\nTipo: {1}\nCoordenadas: {2}\nEstado: {3}\nInicio Incendio: {4}\nFim Incendio: {5}\nOperacionaisIDS: {6}\nViaturasIDS:{7}", id, tipo, string.Join(", ",coordenadas), estado, inicioIncendio, fimIncendio, string.Join(", ", operacionaisIDs), string.Join(", ", viaturasIDs));
        }
        #endregion

        #region Methods

        /// <summary>
        /// Adiciona um operacional à lista de operacionais do objeto incêndio (esta lista apenas contém IDs!)
        /// Antes de chamar esta função, devem ser realizadas outras operações antes:
        /// Confirmar se o operacional existe nos operacionais. (se sim, adicionar! porque ele existe)
        /// Confirmar se já se encontra em algum incêndio. (se sim, não adicionar!)
        /// Por fim, adicionar ao incêndio
        /// </summary>
        /// <param name="id">ID do operacional a adicionar</param>
        /// <returns>True se adicionou, False se não adicionou</returns>
        public bool AdicionarOperacional(int id)
        {
            //"por fora", confirmar se ja existe o operacional nos operacionais!
            if (VerificarOperacionalExisteNoIncendio(id))
                return false;
            else
            {
                operacionaisIDs.Add(id);
                return true;
            }
            
            
        }

        /// <summary>
        /// Remove um operacional da lista de operacionais do objeto incêndio
        /// </summary>
        /// <param name="id">ID do operacional a remover</param>
        /// <returns>True se removeu, False se não removeu</returns>
        public bool RemoverOperacional(int id)
        {
            if (operacionaisIDs.Remove(id))
                return true;
            return false;
        }
        public bool VerificarOperacionalExisteNoIncendio(int id)
        {
            foreach (int idOper in operacionaisIDs)
            {
                if (idOper == id)
                    return true;
                
            }
            return false;
        }

        

        #endregion
    }
}

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
            string operacionaisIDsString = string.Join(";", operacionaisIDs);
            string viaturasIDsString = string.Join(";", viaturasIDs);
            
            return string.Format("ID: {0}\nTipo: {1}\nCoordenadas: {2}\nEstado: {3}\nInicio Incendio: {4}\nFim Incendio: {5}\nOperacionaisIDS: {6}\nViaturasIDS:{7}", id, tipo, coordenadas, estado, inicioIncendio, fimIncendio, operacionaisIDsString, viaturasIDsString);
        }
        #endregion

        #region Methods

        #endregion
    }
}

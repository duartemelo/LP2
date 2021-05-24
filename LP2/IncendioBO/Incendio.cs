/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/
using System;
using System.Collections.Generic;

namespace IncendioBO
{
    public enum Estado
    {
        Extinto,
        Ativo
    }
    /// <summary>
    /// Class incêndio -> esta class apenas é responsável pela criação do objeto, devolver e alterar dados do mesmo.
    /// </summary>
    public class Incendio
    {
       
        #region Attributes

        private int id;
        private string tipo;
        private float[] coordenadas;
        private Estado estado;
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


        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        public float[] Coordenadas
        {
            get => coordenadas;
            set => coordenadas = value;
        }

        public Estado Estado
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

        #endregion

        #region Methods

        #endregion
    }
}

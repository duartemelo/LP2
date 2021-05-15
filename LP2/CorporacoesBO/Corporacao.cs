using System;

namespace CorporacaoBO
{

    public class Corporacao
    {
        #region Attributes
        int id;
        string freguesia;
        string tipo;   
        #endregion

        #region Constructors

        public Corporacao()
        {

        }

        

        #endregion

        #region Properties

        public int Id
        {
            get => id;
            set => id = value; //perigoso??
        }

        public string Freguesia
        {
            get => freguesia;
            set => freguesia = value;
        }

        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        #endregion

        #region Methods

        #endregion
    }
}

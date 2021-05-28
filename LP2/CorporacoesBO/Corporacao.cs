/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

namespace CorporacaoBO
{
    public enum TipoCorp
    {
        Sapadores,
        Voluntarios
    }

    /// <summary>
    /// Class Corporação -> esta class apenas é responsável pela criação do objeto, devolver e alterar dados do mesmo.
    /// </summary>
    public class Corporacao
    {
        #region Attributes
        int id;
        string freguesia;
        TipoCorp tipo;   
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
            set => id = value; 
        }

        public string Freguesia
        {
            get => freguesia;
            set => freguesia = value;
        }

        public TipoCorp Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        #endregion

        #region Overrides, Operators

        public static bool operator ==(Corporacao c1, Corporacao c2)
        {
            return (c1.Equals(c2));
        }

        public static bool operator != (Corporacao c1, Corporacao c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Corporacao c = (Corporacao)obj;
                return (tipo == c.Tipo && freguesia == c.Freguesia);
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nFreguesia: {1}\nTipo: {2}", id, freguesia, tipo);
        }

        #endregion

        #region Methods

        #endregion
    }
}

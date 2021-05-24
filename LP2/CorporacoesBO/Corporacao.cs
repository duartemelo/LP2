/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

namespace CorporacaoBO
{
    /// <summary>
    /// Class Corporação -> esta class apenas é responsável pela criação do objeto, devolver e alterar dados do mesmo.
    /// </summary>
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

        #region Overrides, Operators

        public static bool operator ==(Corporacao c1, Corporacao c2)
        {
            return (c1.Tipo == c2.Tipo && c1.Freguesia == c2.Freguesia);
        }

        public static bool operator != (Corporacao c1, Corporacao c2)
        {
            return !(c1 == c2);
        }

        #endregion

        #region Methods

        #endregion
    }
}

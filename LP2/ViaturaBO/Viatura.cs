/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

namespace ViaturaBO
{
    public enum Estado
    {
        Ativo,
        Inativo
    }

    public enum Tipo
    {
        Mota,
        Carro,
        Helicoptero,
        Aviao
    }
    public class Viatura
    {
        #region Attributes
        private int id;
        private int corporacaoID;
        private Tipo tipoViatura;
        private string matricula;
        private string marca;
        private string modelo;
        private Estado estadoViatura;
        #endregion

        #region Constructors

        public Viatura()
        {

        }

        #endregion

        #region Properties

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int CorporacaoID
        {
            get => corporacaoID;
            set => corporacaoID = value;
        }

        public Tipo TipoViatura
        {
            get => tipoViatura;
            set => tipoViatura = value;
        }

        public string Matricula
        {
            get => matricula;
            set => matricula = value;
        }

        public string Marca
        {
            get => marca;
            set => marca = value;
        }

        public string Modelo
        {
            get => modelo;
            set => modelo = value;
        }

        public Estado EstadoViatura
        {
            get => estadoViatura;
            set => estadoViatura = value;
        }

        #endregion

        #region Overrides, Operators

        public static bool operator ==(Viatura v1, Viatura v2)
        {
            if (v1.matricula == v2.matricula)
                return true;
            return false;
        }
        public static bool operator !=(Viatura v1, Viatura v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            return this == (Viatura)obj;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nCorporacaoID: {1}\nTipoViatura: {2}\nMatricula: {3}\nMarca: {4}\nModelo: {5}\nEstado: {6}", id, corporacaoID, tipoViatura, matricula, marca, modelo, estadoViatura);
        }

        #endregion

    }
}

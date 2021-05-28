/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

namespace ViaturaBO
{
    public enum EstadoViatura
    {
        Ativo,
        Inativo
    }

    public enum TipoViatura
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
        private TipoViatura tipoViatura;
        private string matricula;
        private string marca;
        private string modelo;
        private EstadoViatura estadoViatura;
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

        public TipoViatura TipoViatura
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

        public EstadoViatura EstadoViatura
        {
            get => estadoViatura;
            set => estadoViatura = value;
        }

        #endregion

        #region Overrides, Operators

        public static bool operator ==(Viatura v1, Viatura v2)
        {
            return v1.Equals(v2);
        }
        public static bool operator !=(Viatura v1, Viatura v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Viatura v = (Viatura)obj;
                return (matricula == v.Matricula);
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nCorporacaoID: {1}\nTipoViatura: {2}\nMatricula: {3}\nMarca: {4}\nModelo: {5}\nEstado: {6}", id, corporacaoID, tipoViatura, matricula, marca, modelo, estadoViatura);
        }

        #endregion

    }
}

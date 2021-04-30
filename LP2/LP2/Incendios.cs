/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP2
{
    
    class Incendios
    {
        #region Atributos
        private static int numIncendios;
        private static List<Incendio> incendios;
        #endregion



        #region Construtores
        public Incendios()
        {
            numIncendios = 0;
            incendios = new List<Incendio>();
        }
        #endregion




        #region Propriedades
        public int NumIncendios
        {
            get => numIncendios;
        }
        #endregion





        #region Metodos
        public bool CriarNovoIncendio (string tipo, float[] coordenadas)
        {
            
            //criar incendio
            Incendio novoIncendio = new Incendio(numIncendios, tipo, coordenadas);

            //adicionar incendio a lista
            incendios.Add(novoIncendio);


            //incrementar incendios
            numIncendios++;
            return true;
        }

        public int NumeroIncendiosEstado(string estado)
        {
            int incendiosPorEstado = 0;

            //percorrer lista de incendios e ver os que têm estado ativo
            foreach(Incendio incendio in incendios)
            {
                if (incendio.Estado == estado)
                {
                    incendiosPorEstado++;
                }
            }

            return incendiosPorEstado;
        }

        public void MostrarIncendios()
        {
            foreach (Incendio incendio in incendios)
            {
                incendio.MostrarIncendio();
            }
        }
        #endregion




    }

    class Incendio
    {
        #region Atributos
        private int id;
        private string tipo;
        private float[] coordenadas;
        private string estado;
        //inicio , tempo
        //fim , tempo
        private List<int> operacionaisIDs;
        private List<int> viaturasIDs;
        #endregion

        #region Construtores
        public Incendio(int id, string tipo, float[] coordenadas)
        {
            this.id = id;
            estado = "ativo";
            this.coordenadas = coordenadas;
            this.tipo = tipo;
            operacionaisIDs = new List<int>();
            viaturasIDs = new List<int>();
        }
        #endregion


        #region Propriedades
        public int Id
        {
            get => id;
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

        public string Estado
        {
            get => estado;
            set => estado = value;
        }
        #endregion


        #region Metodos
        //neste momento está inutil porque existe o set
        /*public bool DefinirEstadoIncendio(string estadoRecebido)
        {
            estado = estadoRecebido;
            return true;
        }*/


        public bool AdicionarOperacional (int id)
        {
            operacionaisIDs.Add(id);
            return true;
        }

        public bool RemoverOperacional(int id)
        {
            operacionaisIDs.Remove(id);
            return true;
        }

        public bool AdicionarViatura(int id)
        {
            viaturasIDs.Add(id);
            return true;
        }

        public bool RemoverViatura(int id)
        {
            viaturasIDs.Remove(id);
            return true;
        }

        public void MostrarIncendio()
        {
            Console.WriteLine(id);
            Console.WriteLine(estado);
            Console.WriteLine(tipo);
            Console.WriteLine(coordenadas[0].ToString() + " " + coordenadas[1].ToString());
        }
        #endregion

    }
}

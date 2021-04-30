using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP2
{
    class Incendios
    {
        //Atributos
        static int numIncendios;
        static List<Incendio> incendios;




        //Construtor
        public Incendios()
        {
            numIncendios = 0;
            incendios = new List<Incendio>();
        }




        //Propriedades
        public int NumIncendios
        {
            get => numIncendios;
        }





        //Métodos
        public bool CriarNovoIncendio (string tipo, float[] coordenadas)
        {
            
            //criar incendio
            Incendio novoIncendio = new Incendio();
            //definir id incendio
            novoIncendio.Id = numIncendios;
            //definir tipo incendio
            novoIncendio.Tipo = tipo;
            //definir coordenadas
            novoIncendio.Coordenadas = coordenadas;

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

        public Incendio EncontrarIncendioId(int id)
        {
            Incendio incendioEncontrado = null;
            foreach(Incendio incendio in incendios)
            {
                if (incendio.Id == id)
                {
                    incendioEncontrado = incendio;
                }
            }
            return incendioEncontrado;
        }


    }

    class Incendio
    {
        int id;
        string tipo;
        float[] coordenadas;
        string estado;
        //inicio , tempo
        //fim , tempo
        List<int> operacionaisIDs;
        List<int> viaturasIDs;

        public Incendio()
        {
            estado = "ativo";
            coordenadas = new float[2];
            operacionaisIDs = new List<int>();
            viaturasIDs = new List<int>();
        }

        

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

        public string Estado
        {
            get => estado;
            set => estado = value;
        }

        public bool DefinirEstadoIncendio(string estadoRecebido)
        {
            estado = estadoRecebido;
            return true;
        }


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
        }

    }
}

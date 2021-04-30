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
        public static int NumIncendios
        {
            get => numIncendios;
        }





        //Métodos
        public static bool CriarNovoIncendio (string tipo, float[] coordenadas)
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

        public static bool DefinirEstadoIncendio (int id, string estado)
        {
            Incendio encontrado = incendios.Find(x => x.Id == id);
            encontrado.Estado = estado;
            return true;
        }


    }

    class Incendio
    {
        static int id;
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


        public static Incendio AdicionarOperacional (Incendio incendio, int id)
        {
            incendio.operacionaisIDs.Add(id);
            return incendio;
        }

        public static Incendio RemoverOperacional(Incendio incendio, int id)
        {
            incendio.operacionaisIDs.Remove(id);
            return incendio;
        }

        public static Incendio AdicionarViatura(Incendio incendio, int id)
        {
            incendio.viaturasIDs.Add(id);
            return incendio;
        }

        public static Incendio RemoverViatura(Incendio incendio, int id)
        {
            incendio.viaturasIDs.Remove(id);
            return incendio;
        }

    }
}

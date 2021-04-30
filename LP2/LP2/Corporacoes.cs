using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP2
{
    class Corporacoes
    {
        //Atributos
        static int numCorporacoes;
        static List<Corporacao> corporacoes;

        //Construtor
        public Corporacoes()
        {
            numCorporacoes = 0;
            corporacoes = new List<Corporacao>();
        }

        //Propriedades
        public static int NumCorporacoes
        {
            get => numCorporacoes;
        }



    }

    class Corporacao
    {
        int id;
        string freguesia;
        string tipo;

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

        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }


    }
}

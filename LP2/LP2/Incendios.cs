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
    enum Estado
    {
        Ativo,
        Extinto
    }
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

        /// <summary>
        /// Função para criar um novo incêndio
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="coordenadas"></param>
        /// <param name="estado">Este argumento não tem de ser obrigatoriamente passado, e caso não seja, o default é ativo.</param>
        /// <returns></returns>
        public bool CriarNovoIncendio (string tipo, float[] coordenadas, Estado estado = Estado.Ativo)
        {
            
            //criar incendio
            Incendio novoIncendio = new Incendio(numIncendios, tipo, coordenadas, estado);

            //verificar se coordenadas ja existem (não faria sentido repetir o incêndio)
            //a segunda confirmação, permite que com um incendio ativo, adicionemos um extinto (passado) nesse mesmo local
            if (VerificarCoordenadas(coordenadas) == true && novoIncendio.Estado != Estado.Extinto)
            {
                //Será boa pratica Console.WriteLine aqui dentro?
                Console.WriteLine("Estas coordenadas já estão associadas a algum incêndio ativo.");
                return false;
            }

            //adicionar incendio a lista
            incendios.Add(novoIncendio);
            Console.WriteLine("incendio add");

            //incrementar incendios
            //test
            numIncendios++;
            return true;
        }

        /// <summary>
        /// Verificar se as coordenadas já existem nos incêndios (possivelmente, criar uma função generica e juntar a Viaturas.VerificarSeJaExiste, etc.
        /// </summary>
        /// <param name="coordenadas"></param>
        /// <returns></returns>
        public bool VerificarCoordenadas(float[] coordenadas)
        {
            foreach (Incendio incendio in incendios){
                if ((incendio.Coordenadas == coordenadas) && incendio.Estado != Estado.Extinto)
                {
                    //caso as coordenadas já existam e o incendio não esteja extinto
                    return true;
                }
            }
            return false;
        }

        
        
        /// <summary>
        /// Função que devolve o número de incêndios por estado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public int NumeroIncendiosEstado(Estado estado)
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
         
        /// <summary>
        /// Mostra todos os incêndios
        /// </summary>
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
        private Estado estado;
        //inicio , tempo
        //fim , tempo
        private List<int> operacionaisIDs;
        private List<int> viaturasIDs;
        #endregion

        #region Construtores
        public Incendio(int id, string tipo, float[] coordenadas, Estado estado)
        {
            this.id = id;
            this.estado = estado;
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

        public Estado Estado
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

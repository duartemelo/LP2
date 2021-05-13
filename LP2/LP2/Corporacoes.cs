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
    class Corporacoes
    {
        #region Atributos
        private static int numCorporacoes;
        private static List<Corporacao> corporacoes;
        #endregion

        #region Construtores
        public Corporacoes()
        {
            numCorporacoes = 0;
            corporacoes = new List<Corporacao>();
        }
        #endregion

        #region Propriedades
        public static int NumCorporacoes
        {
            get => numCorporacoes;
        }
        #endregion


        #region Metodos
        public bool CriarNovaCorporacao(string freguesia, string tipo)
        {
            Corporacao novaCorporacao = new Corporacao(numCorporacoes, freguesia, tipo);
            corporacoes.Add(novaCorporacao);
            numCorporacoes++;
            return true;
        }

        public int NumeroCorporacoesPorTipo(string tipo)
        {
            int corporacoesPorTipo = 0;

            foreach (Corporacao corporacao in corporacoes)
            {
                if (corporacao.Tipo == tipo)
                {
                    corporacoesPorTipo++;
                }
                
            }

            return corporacoesPorTipo;
        }

        public void MostrarCorporacoes()
        {
            foreach(Corporacao corporacao in corporacoes)
            {
                corporacao.MostrarCorporacao();
            }
        }

        /// <summary>
        /// Verificar se existe uma corporação a partir de um ID (util para adicionar viaturas, por exemplo)
        /// </summary>
        /// <param name="id">ID da corporaçãp</param>
        /// <returns></returns>
        public static bool VerExisteCorporacaoID(int id)
        {
            foreach(Corporacao corporacao in corporacoes)
            {
                if (corporacao.Id == id)
                {
                    return true;
                }
            }
            return false;
        }


        #endregion


    }

    class Corporacao
    {
        #region Atributos
        int id;
        string freguesia;
        string tipo;
        #endregion

        #region Construtores
        public Corporacao(int id, string freguesia, string tipo)
        {
            this.id = id;
            this.freguesia = freguesia;
            this.tipo = tipo;
        }
        #endregion

        #region Propriedades
        public int Id
        {
            get => id;
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

        #region Metodos
        public void MostrarCorporacao()
        {
            Console.WriteLine(id);
            Console.WriteLine(freguesia);
            Console.WriteLine(tipo);
        }
        #endregion


    }
}

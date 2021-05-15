using System;
using System.Collections.Generic;
using CorporacaoBO;
using CorporacaoOutput;

namespace CorporacaoData
{
    
    public class CorporacaoDados
    {
        #region Attributes

        private static int numCorporacoes = 0;
        private static int numIDs = numCorporacoes;
        private static List<Corporacao> corporacoes = new List<Corporacao>();


        #endregion

        #region Constructors

        #endregion

        #region Properties

        public static int NumCorporacoes
        {
            get => numCorporacoes;
        }

        #endregion

        #region Methods

        public static bool AddCorporacao(Corporacao c) 
        {
            if (VerificarCorporacaoExiste(c.Tipo, c.Freguesia))
                return false;
            c.Id = numIDs;
            corporacoes.Add(c);
            numCorporacoes++;
            numIDs++;
            return true;
            
        }

        public static bool RemoveCorporacao (Corporacao c)
        {
            if (corporacoes.Remove(c))
            {
                numCorporacoes--;
                return true;
            }
            else
                return false;
            
        }

        public static bool VerificarCorporacaoExiste(string tipo, string freguesia)
        {
            foreach (Corporacao corporacao in corporacoes)
            {
                if (corporacao.Tipo == tipo && corporacao.Freguesia == freguesia)
                {
                    return true;
                }
            }
            return false;
        }

        public static Corporacao ObterCorporacaoPeloId(int id)
        {
            foreach(Corporacao corporacao in corporacoes)
            {
                if (corporacao.Id == id)
                    return corporacao;
            }
            return null;
        }

        public static int NumeroCorporacoesPorTipo(string tipo)
        {
            int corporacoesPorTipo = 0;
            foreach(Corporacao corporacao in corporacoes)
            {
                if (corporacao.Tipo == tipo)
                {
                    corporacoesPorTipo++;
                }
            }

            return corporacoesPorTipo;
        }

        public static void MostraCorporacoes()
        {
            CorporacaoEscreve.MostraCorporacoes(corporacoes);
        }

        #endregion
    }
}

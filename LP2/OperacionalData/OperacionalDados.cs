using System;
using System.Collections.Generic;
using OperacionalBO;
using OperacionalOutput;

namespace OperacionalData
{
    public class OperacionalDados
    {
        #region Attributes

        private static int numOperacionais = 0;
        private static int numIDs = 1;
        private static List<Operacional> operacionais = new List<Operacional>();

        #endregion

        #region Properties

        public static int NumOperacionais
        {
            get => numOperacionais;
        }

        #endregion

        #region Methods

        public static bool AddOperacional(Operacional o)
        {
            if (VerificaSeOperacionalExiste(o))
                return false;
            o.Id = numIDs;
            operacionais.Add(o);
            numOperacionais++;
            numIDs++;
            return true;
        }

        public static bool RemoveOperacional(Operacional o)
        {
            if (operacionais.Remove(o))
            {
                numOperacionais--;
                return true;
            }
            return false;
        }

        public static bool VerificaSeOperacionalExiste(Operacional o)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional == o)
                    return true;
            }
            return false;
        }

        public static bool VerificaSeOperacionalExiste(int id)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == id)
                    return true;
            }
            return false;
        }

        public static void MostraOperacionais()
        {
            OperacionalEscreve.MostraOperacionais(operacionais);
        }

        public static bool AdicionarOperacionalACorporacao(int idOper, int idCorp)
        {
            foreach(Operacional operacional in operacionais)
            {
                if(operacional.Id == idOper)
                {
                    if (operacional.Estado == EstadoOperacional.Ativo)
                    {
                        operacional.CorporacaoID = idCorp;
                        return true;
                    }
                    
                }
            }
            return false;


            
        }

        public static Operacional DevolveOperacionalPeloId(int idOper)
        {
            foreach(Operacional operacional in operacionais)
            {
                if(operacional.Id == idOper)
                {
                    return operacional;
                }
            }
            return null;
        }

        public static bool RemoveOperacionalDeCorporacao(int idOper)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == idOper)
                {
                    operacional.CorporacaoID = 0;
                    return true;
                }
            }
            return false;
        }

        public static bool AlterarCargoOper(int idOper, string novoCargo)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == idOper)
                {
                    operacional.Cargo = novoCargo;
                    return true;
                }
            }
            return false;
        }

        public static bool AlterarSalarioOper(int idOper, float novoSalario)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == idOper)
                {
                    if (operacional.Estado == EstadoOperacional.Ativo)
                    {
                        if (operacional.CorporacaoID != 0)
                        {
                            operacional.Salario = novoSalario;
                            return true;
                        }
                    }
                    
                }
            }
            return false;
        }

        public static bool InativarOper(int idOper)
        {
            foreach(Operacional operacional in operacionais)
            {
                if (operacional.Id == idOper)
                {
                    operacional.Estado = EstadoOperacional.Inativo;
                    operacional.CorporacaoID = 0;
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}

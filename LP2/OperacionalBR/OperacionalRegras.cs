﻿using System;
using OperacionalBO;
using OperacionalData;
using GeneralOutputs;
using CorporacaoBR;


namespace OperacionalBR
{
    public class OperacionalRegras
    {
        public static bool InsereOperacional(Operacional o)
        {
            try
            {
                if (OperacionalValidoParaInserir(o))
                {
                    return OperacionalDados.AddOperacional(o);
                }
                else
                {
                    GeneralEscreve.EscreveErro("Operacional não se encontra válido para inserir!"); //passar para exception?
                    return false;
                }
                    
                    
            } catch (Exception e)
            {
                throw e;
            }
        }

        public static bool RemoveOperacional (Operacional o)
        {
            try
            {
                return OperacionalDados.RemoveOperacional(o);
            } catch(Exception e)
            {
                throw e;
            }
        }

        public static bool OperacionalValidoParaInserir(Operacional o)
        {
            if (o != null || o.Nome != null)
                return true;
            return false;
        }

        public static void MostraOperacionais()
        {
            OperacionalDados.MostraOperacionais();
        }

        public static bool VerificaSeOperacionalExiste(int id)
        {
            return OperacionalDados.VerificaSeOperacionalExiste(id);
        }

        public static bool AdicionarOperacionalACorporacao(int idOper, int idCorp)
        {
            if (CorporacaoRegras.VerificarCorporacaoExiste(idCorp))
            {
                return(OperacionalDados.AdicionarOperacionalACorporacao(idOper, idCorp));
            }
            return false;
        }

        public static bool RemoveOperacionalDeCorporacao(int idOper)
        {
            return OperacionalDados.RemoveOperacionalDeCorporacao(idOper);
        }

        public static Operacional DevolveOperacionalPeloId(int idOper)
        {
            return (OperacionalDados.DevolveOperacionalPeloId(idOper));
        }

        public static bool AlterarCargoOper(int idOper, string novoCargo)
        {
            return (OperacionalDados.AlterarCargoOper(idOper, novoCargo));
        }

        public static bool AlterarSalarioOper(int idOper, float novoSalario)
        {
            return (OperacionalDados.AlterarSalarioOper(idOper, novoSalario));
        }

        public static bool InativarOper(int idOper)
        {
            return (OperacionalDados.InativarOper(idOper));
        }
    }
}

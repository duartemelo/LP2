﻿using System;
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

        #endregion
    }
}
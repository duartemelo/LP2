using System;
using System.Collections.Generic;
using IncendioBO;
using IncendioOutput;

namespace IncendioData
{
    public class IncendioDados
    {
        #region Attributes
        private static int numIncendios = 0;
        private static int numIDs = numIncendios;
        private static List<Incendio> incendios = new List<Incendio>();

        #endregion

        #region Constructors
        #endregion

        #region Properties

        public static int NumIncendios
        {
            get => numIncendios;
        }

        #endregion

        #region Methods

        public static bool AddIncendio(Incendio i)
        {
            if (VerificarSePodeSerAdd(i.Coordenadas, i.Estado) == false)
            {
                //Ao adicionar um incendio extinto, pode existir um ativo/extinto naquela loc; Ao adicionar um ativo, podem existir APENAS extintos na loc
                return false;
            }
            
            i.Id = numIDs;
            incendios.Add(i);
            numIncendios++;
            numIDs++;
            return true;
        }

        public static bool RemoveIncendio(Incendio i)
        {
            if (incendios.Remove(i))
            {
                numIncendios--;
                return true;
            }
            else
                return false;
        }

        public static int NumeroIncendiosPorEstado(Estado estado)
        {
            int incendiosEstado = 0;
            foreach (Incendio incendio in incendios)
            {
                if (incendio.Estado == estado)
                    incendiosEstado++;
            }
            return incendiosEstado;
        }

        public static bool VerificarSePodeSerAdd(float[] coordenadas, Estado estado)
        {
            foreach(Incendio incendio in incendios)
            {
                if(incendio.Coordenadas == coordenadas)
                {
                    if (estado == Estado.Extinto)
                    {
                        return true;
                    }
                    else if(estado == Estado.Ativo && incendio.Estado == Estado.Extinto)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void MostraIncendios()
        {
            IncendioEscreve.MostraIncendios(incendios);
        }

        #endregion
    }
}

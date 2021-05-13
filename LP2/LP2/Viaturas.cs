﻿/**
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
    class Viaturas
    {
        #region Atributos
        private static int numViaturas;
        private static List<Viatura> viaturas;
        #endregion

        #region Construtores
        public Viaturas()
        {
            numViaturas = 0;
            viaturas = new List<Viatura>();
        }
        #endregion

        #region Propriedades
        public static int NumViaturas
        {
            get => numViaturas;
        }
        #endregion

        #region Metodos
        public bool CriarNovaViatura(int corporacaoID, string tipo, string matricula, string marca, string modelo, string estado)
        {
            Viatura novaViatura = new Viatura(numViaturas, corporacaoID, tipo, matricula, marca, modelo, estado);

            if (matricula != null && VerificarSeJaExiste(matricula) == true)
            {
                //Console.WriteLine aqui será boa prática??
                Console.WriteLine("Esta viatura já existe, por favor, experimente transferir a mesma de corporação.");
                return false;
            }
            if (Corporacoes.VerExisteCorporacaoID(corporacaoID) == false)
            {
                Console.WriteLine("Corporação não existe.");
                return false;
            }
            viaturas.Add(novaViatura);
            numViaturas++;
            return true;
        }

        public bool VerificarSeJaExiste(string matricula)
        {

            foreach(Viatura viatura in viaturas)
            {
                if (viatura.Matricula == matricula)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Remove uma viatura da lista de viaturas pelo ID
        /// </summary>
        /// <param name="id">ID da viatura a ser removida</param>
        /// <returns></returns>
        public bool RemoverViaturaId(int id)
        {
            if(RemoverViatura(EncontrarViaturaId(id)) == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove uma viatura da lista de viaturas
        /// </summary>
        /// <param name="viatura">Viatura a ser removida</param>
        /// <returns></returns>
        public bool RemoverViatura(Viatura viatura)
        {
            return viaturas.Remove(viatura);
        }

        /// <summary>
        /// Encontra uma viatura a partir do seu ID
        /// </summary>
        /// <param name="id">ID da viatura</param>
        /// <returns></returns>
        public Viatura EncontrarViaturaId(int id)
        {
            foreach(Viatura viatura in viaturas)
            {
                if(viatura.Id == id)
                {
                    return viatura;
                }
            }
            return null;
        }

        public int NumeroViaturasPorTipo(string tipo)
        {
            int viaturasPorTipo = 0;
            foreach(Viatura viatura in viaturas)
            {
                if (viatura.Tipo == tipo)
                {
                    viaturasPorTipo++;
                }
            }
            return viaturasPorTipo;
        }

        public void MostrarViaturas()
        {
            foreach(Viatura viatura in viaturas){
                viatura.MostrarViatura();
            }
        }
        #endregion

    }

    class Viatura
    {
        #region Atributos
        private int id;
        private int corporacaoID;
        private string tipo;
        private string matricula;
        private string marca;
        private string modelo;
        private string estado;
        #endregion

        #region Construtores
        public Viatura(int id, int corporacaoID, string tipo, string matricula, string marca, string modelo, string estado)
        {
            this.id = id;
            this.corporacaoID = corporacaoID;
            this.tipo = tipo;
            this.matricula = matricula;
            this.marca = marca;
            this.modelo = modelo;
            this.estado = estado;
        }
        #endregion

        #region Propriedades
        public int Id
        {
            get => id;
        }
        public int CorporacaoID
        {
            get => corporacaoID;
            set => corporacaoID = value;
        }

        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        public string Matricula
        {
            get => matricula;
            set => matricula = value;
        }

        public string Marca
        {
            get => marca;
            set => marca = value;
        }

        public string Modelo
        {
            get => modelo;
            set => modelo = value;
        }

        public string Estado
        {
            get => estado;
            set => estado = value;
        }
        #endregion

        #region Metodos
        public void MostrarViatura()
        {
            Console.WriteLine(id);
            Console.WriteLine(corporacaoID);
            Console.WriteLine(tipo);
            if (matricula != null) Console.WriteLine(matricula);
            Console.WriteLine(marca);
            Console.WriteLine(modelo);
            Console.WriteLine(estado);
            }
        #endregion
    }
}

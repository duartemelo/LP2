﻿using System;

namespace OperacionalBO
{
    public enum EstadoOperacional
    {
        Inativo,
        Ativo
    }
    public class Operacional
    {
        #region Attributes

        private int id;
        private int cc; //cartao cidadao
        private int corporacaoID;
        private string nome;
        private string cargo;
        private float salario;
        private EstadoOperacional estado;
        DateTime dataNasc;

        #endregion

        #region Constructors

        public Operacional()
        {

        }

        #endregion

        #region Properties

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Cc
        {
            get => cc;
            set => cc = value;
        }

        public int CorporacaoID
        {
            get => corporacaoID;
            set => corporacaoID = value;
        }

        public string Nome
        {
            get => nome;
            set => nome = value;
        }

        public string Cargo
        {
            get => cargo;
            set => cargo = value;
        }

        public float Salario
        {
            get => salario;
            set => salario = value;
        }

        public EstadoOperacional Estado
        {
            get => estado;
            set => estado = value;
        }

        public DateTime DataNasc
        {
            get => dataNasc;
            set => dataNasc = value;
        }
        #endregion

        #region Overrides, Operators

        public static bool operator == (Operacional o1, Operacional o2)
        {
            return (o1.cc == o2.cc);
        }

        public static bool operator != (Operacional o1, Operacional o2)
        {
            return !(o1 == o2);
        }

        public override bool Equals(object obj)
        {
            return this == (Operacional)obj;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nCC: {1}\nCorporacaoID: {2}\nNome: {3}\nCargo: {4}\nSalario: {5}\nEstado: {6}\nDataNasc: {7}", id, cc, corporacaoID, nome, cargo, salario, estado, dataNasc);
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_dotnet
{
    abstract class Cliente
    {
        protected string nome;
        protected string cpfCnpj;
        protected double saldo;

        public double Saldo
        {
            get { return saldo; }
        }

        public string Nome
        {
            get { return nome; }
        }

        public string CpfCnpj
        {
            get { return cpfCnpj; }
        }

        public Cliente(string nome, string cpfCnpj, double saldoInicial)
        {
            this.nome = nome;
            this.cpfCnpj = cpfCnpj;
            this.saldo = saldoInicial;
        }

        public abstract void Sacar(double valor);

        public void Depositar(double valor)
        {
            saldo += valor;
        }
    }
}

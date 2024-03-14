using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_dotnet
{
    class ContaPoupanca : Cliente
    {
        public ContaPoupanca(string nome, string cpf, double saldoInicial)
            : base(nome, cpf, saldoInicial)
        {
        }

        public override void Sacar(double valor)
        {
            if (valor > 0 && valor <= saldo && !ePoupanca())
            {
                saldo -= valor;
                Console.WriteLine($"Saque de {valor} realizado com sucesso para a conta poupança de {nome}");
            }
            else if (ePoupanca())
            {
                Console.WriteLine($"Conta poupança não pode realizar saques");
            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para o saque de {valor} para a conta poupança de {nome}");
            }
        }

        public bool ePoupanca()
        {
            return true;
        }
    }
}

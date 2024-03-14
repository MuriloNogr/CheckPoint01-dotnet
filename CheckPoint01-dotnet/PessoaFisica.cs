using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_dotnet
{
    class PessoaFisica : Cliente
    {
        public PessoaFisica(string nome, string cpf, double saldoInicial)
            : base(nome, cpf, saldoInicial)
        {
        }

        public override void Sacar(double valor)
        {
            if (valor > 0 && valor <= saldo)
            {
                saldo -= valor;
                Console.WriteLine($"Saque de {valor} realizado com sucesso para o cliente PF {nome}");
            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para o saque de {valor} para o cliente PF {nome}");
            }
        }
    }
}

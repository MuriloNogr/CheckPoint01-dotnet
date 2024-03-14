using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_dotnet
{
    class PessoaJuridica : Cliente
    {
        public PessoaJuridica(string nome, string cnpj, double saldoInicial)
            : base(nome, cnpj, saldoInicial)
        {
        }

        public override void Sacar(double valor)
        {
            if (valor > 0 && valor <= saldo)
            {
                saldo -= valor;
                Console.WriteLine($"Saque de {valor} realizado com sucesso para o cliente PJ {nome}");
            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para o saque de {valor} para o cliente PJ {nome}");
            }
        }
    }
}

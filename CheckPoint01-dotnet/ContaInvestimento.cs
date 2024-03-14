using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_dotnet
{
    class ContaInvestimento : Cliente
    {
        public ContaInvestimento(string nome, string cpf, double saldoInicial)
            : base(nome, cpf, saldoInicial)
        {
        }

        public double CalcularRendimento(double taxa)
        {
            taxa = 0.5;

            if (taxa > 0)
            {
                Console.WriteLine("Os os seus investimentos estão rendendo!");
                return saldo * taxa;
            }
            else
            {
                Console.WriteLine("Os os seus investimentos não estão rendendo!");
                return saldo * taxa;
            }
        }

        public double CalcularIOF(double valorRetirado)
        {
            // Simples cálculo de IOF
            if (valorRetirado > saldo)
                return 0;

            double iof = valorRetirado * 0.02;
            return iof;
        }

        public override void Sacar(double valor)
        {
            if (valor > 0 && valor <= saldo)
            {
                saldo -= valor;
                Console.WriteLine($"Saque de {valor} realizado com sucesso para a conta de investimento de {nome}");
            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para o saque de {valor} para a conta de investimento de {nome}");
            }
        }

        public void VerificarRendimento()
        {
            Console.WriteLine("Verificando rendimentos da conta de investimento...");
            Console.WriteLine("Rendimento calculado com sucesso!" + CalcularRendimento(0.5));
        }

        public void CalcularIOF()
        {
            Console.WriteLine("Calculando IOF da conta de investimento...");
            Console.WriteLine("IOF calculado com sucesso!" + CalcularIOF(1000));
        }
    }

}

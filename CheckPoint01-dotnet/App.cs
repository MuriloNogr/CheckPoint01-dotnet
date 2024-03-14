using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint01_dotnet
{
    class App
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao BancoApp!");

            List<Cliente> contas = new List<Cliente>();

            PessoaFisica clientePF = new PessoaFisica("João", "123.456.789-10", 1000);
            PessoaJuridica clientePJ = new PessoaJuridica("Empresa XYZ", "00.000.000/0001-00", 5000);
            ContaPoupanca contaPoupanca = new ContaPoupanca("Maria", "111.222.333-44", 200);
            ContaInvestimento contaInvestimento = new ContaInvestimento("José", "555.666.777-88", 3000);

            double saldoTotal = CalcularSaldoTotal(contas);
            contas.Add(clientePF);
            contas.Add(clientePJ);
            contas.Add(contaPoupanca);
            contas.Add(contaInvestimento);

            clientePF.Depositar(500);
            clientePF.Sacar(200);

            clientePJ.Depositar(1000);
            clientePJ.Sacar(500);

            contaPoupanca.Depositar(300);
            contaPoupanca.Sacar(100);

            contaInvestimento.Depositar(1000);
            contaInvestimento.Sacar(500);
            contaInvestimento.CalcularRendimento(0.5);
            contaInvestimento.CalcularIOF(1000);


            Console.WriteLine($"Saldo do cliente PF: {clientePF.Saldo}");
            Console.WriteLine($"Saldo do cliente PJ: {clientePJ.Saldo}");
            Console.WriteLine($"Saldo da conta poupança: {contaPoupanca.Saldo}");
            Console.WriteLine($"Saldo da conta de investimento: {contaInvestimento.Saldo}");
            Console.WriteLine($"Rendimento da conta de investimento: {contaInvestimento.CalcularRendimento(0.5)}");
            Console.WriteLine($"IOF da conta de investimento: {contaInvestimento.CalcularIOF(1000)}");
            Console.WriteLine($"Saldo total em todas as contas: {saldoTotal}");
            VerificarCPFs(contas);


            static double CalcularSaldoTotal(List<Cliente> contas)
            {
                double saldoTotal = 0;
                foreach (var conta in contas)
                {
                    saldoTotal += conta.Saldo;
                }
                return saldoTotal;
            }
        }

        static void VerificarCPFs(List<Cliente> contas)
        {
            foreach (var conta in contas)
            {
                string cpf = conta.CpfCnpj;
                if (ValidarCPF(cpf))
                    Console.WriteLine($"O CPF {cpf} da conta de {conta.Nome} é válido.");
                else
                    Console.WriteLine($"O CPF {cpf} da conta de {conta.Nome} é inválido.");
            }
        }
        static bool ValidarCPF(string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !cpf.All(char.IsDigit))
                return false;

            bool todosIguais = true;
            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    todosIguais = false;
                    break;
                }
            }
            if (todosIguais) return false;

            int[] pesos = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * pesos[i];

            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            if (digitoVerificador1 != cpf[9] - '0')
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * pesos[i];

            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            return digitoVerificador2 == cpf[10] - '0';
        }
    }


}

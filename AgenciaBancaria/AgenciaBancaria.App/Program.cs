using AgenciaBancaria.Dominio;
using System;

namespace AgenciaBancaria.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("Rua teste", "12345678", "Barueri", "São Paulo", "SP");
                Cliente cliente = new Cliente("Rodrigo", "123456", "456789", endereco);
                ContaCorrente conta = new ContaCorrente(cliente, 100);

                Console.WriteLine("Conta " + conta.Situacao + ": " + conta.NumeroConta + "-" + 
                    conta.DigitoVerificador);
                
                string senha = "abc123456789";
                conta.Abrir(senha);

                Console.WriteLine("Conta " + conta.Situacao + ": " + conta.NumeroConta + "-" +
                    conta.DigitoVerificador);

                // Utilização da conta
                conta.Sacar(10, senha);
                Console.WriteLine(conta.VerSaldo());

                conta.Depositar(50);
                Console.WriteLine(conta.VerSaldo());

                conta.Sacar(20, senha);
                Console.WriteLine(conta.VerSaldo());

                conta.Depositar(10);
                Console.WriteLine(conta.VerExtrato());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

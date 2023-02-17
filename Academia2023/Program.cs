using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using Academia2023.AlfaPeople.ConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Academia2023.Controller;
using Academia2023.Model;

namespace Academia2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrmServiceClient serviceClient = Singleton.GetService();
            ContaController contaController = new ContaController(serviceClient);
            ContatoController contatoController = new ContatoController(serviceClient);
            Guid accountId = CreateAccount(contaController);
            CreateContact(contatoController, accountId);
        }

        private static void CreateContact(ContatoController contatoController, Guid accountId)
        {
            Console.WriteLine("Você deseja criar um contato para essa conta? (S/N)");
            string simOuNao = Console.ReadLine().ToUpper();

            if (simOuNao == "S")
            {
                Console.WriteLine("Por favor informe o nome do contato:");
                string nomeDoContato = Console.ReadLine();

                Console.WriteLine("Por favor informe o cpf dao contato:");
                string cpf = Console.ReadLine();

                Console.WriteLine("Por favor informe o telefone do contato:");
                string telefone = Console.ReadLine();

                Entity contato = contatoController.GetContactByCpf(cpf);

                while(contato != null)
                {
                    Console.WriteLine("Contato já existente com esse cpf");
                    Console.WriteLine("Por favor informe um cpf não existente:");
                    cpf = Console.ReadLine();
                    contato = contatoController.GetContactByCpf(cpf);
                }

                Console.WriteLine("Aguarde enquanto o novo contato é criada");
                Guid contactId = contatoController.Create(nomeDoContato, cpf, telefone, accountId);
                Console.WriteLine("Contato criado com sucesso");
            }
            else
            {
                return;
            }
        }

        private static Guid CreateAccount(ContaController contaController)
        {
            Console.WriteLine("Por favor informe o nome da conta:");
            string nomeDaConta = Console.ReadLine();

            Console.WriteLine("Por favor informe o Cnpj da conta:");
            string cnpj = Console.ReadLine();

            Console.WriteLine("Por favor informe a idade da conta:");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Por favor informe a porcentagem do lucro da conta:");
            decimal porcentagem = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Por favor informe a categoria(MEI/LTDA) da conta:");
            string nomeCategoria = Console.ReadLine().ToUpper();

            Console.WriteLine("Por favor informe o tipo de venda(VAREJO/ATACADO) da conta:");
            int tipoDeVenda = ValorDaListaOpcoes();

            Entity conta = contaController.GetContaByCnj(cnpj);

            while (conta != null)
            {
                Console.WriteLine("Conta já existente com esse cnpj");
                Console.WriteLine("Por favor informe um cnpj não existente:");
                cnpj = Console.ReadLine();
                conta = contaController.GetContaByCnj(cnpj);
            }

            Console.WriteLine("Aguarde enquanto a nova conta é criada");
            Guid accountId = contaController.Create(nomeDaConta, cnpj, idade, porcentagem, nomeCategoria, tipoDeVenda);
            Console.WriteLine("Conta criada com sucesso");
            return accountId;
        }

        private static int ValorDaListaOpcoes()
        {
            Console.WriteLine("VAREJO");
            Console.WriteLine("ATACADO");
            string resposta = Console.ReadLine().ToUpper();
            int valor = 0;
            if (resposta == "VAREJO")
                valor = 1;
            else
                valor = 2;

            return valor;
        }

    }
}
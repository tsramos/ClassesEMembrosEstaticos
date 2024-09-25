using ClassesEMembrosEstaticos.Entidades;
using ClassesEMembrosEstaticos.Enumeradores;
using System;
using System.Collections.Generic;

namespace ClassesEMembrosEstaticos
{
    internal static class Program
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        static void Main(string[] args)
        {
            Console.WriteLine("Selecione dentre as opçoes: \n\t1)Cadastro\n\t2)Listar \n\t3)Remover \n\t4)Buscar");
            Menu menu = Enum.Parse<Menu>(Console.ReadLine());
            Console.Clear();

            switch (menu)
            {
                case Menu.Cadastro:
                    CadastroMenu();
                    break;
                case Menu.Listar:
                    break;
                case Menu.Remover:
                    break;
                case Menu.Buscar:
                    break;
                default:
                    break;
            }

            Console.WriteLine("Informe o quem deseja cadastrar\n\t1) Pessoas\n\t2) Clientes \n\t3)Funcionarios");
        }

        public static void CadastroMenu()
        {
            Console.WriteLine("Selecione qual entidade deseja cadastrar");
            Console.WriteLine("\t1)Pessoas\n\t2)Clientes\n\t3)Funcionarios");
            SubMenu subMenu = Enum.Parse<SubMenu>(Console.ReadLine());
            switch (subMenu)
            {
                case SubMenu.Pessoas:
                    {
                        var pessoa = CadastroPessoa();
                        pessoas.Add(pessoa);
                        break;
                    }
                case SubMenu.Clientes:
                    CadastroCliente();
                    break;
                case SubMenu.Funcionarios:
                    CadastroFuncionario();
                    break;
                default:
                    Console.WriteLine("Opção invalida");
                    break;
            }

            Console.Clear() ;
        }

        public static Pessoa CadastroPessoa()
        {
            Console.WriteLine("Informe o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o nascimento");
            DateTime nascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Informe o cpf");
            string cpf = Console.ReadLine();
            return new Pessoa(nome, nascimento, cpf);
        }

        public static void CadastroCliente()
        {
            var pessoa = CadastroPessoa();
            Cliente cliente = pessoa as Cliente;
            Console.WriteLine("Informe a data de criação");
            DateTime dataCriacao = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Informe o Genero da pessoa \n\t1) Masculino \n\t2)Feminino");
            Genero genero = Enum.Parse<Genero>(Console.ReadLine());
            cliente.DataCadastro = dataCriacao;
            cliente.Genero = genero;
            pessoas.Add(cliente);
        }

        public static void CadastroFuncionario()
        {
            var pessoa = CadastroPessoa();
            Funcionario funcionario = pessoa as Funcionario;
            int matricula = int.Parse(Console.ReadLine());
            funcionario.Matricula = matricula;
            string cargo = Console.ReadLine();
            funcionario.Cargo = cargo;
            pessoas.Add(funcionario);
        }


    }
}

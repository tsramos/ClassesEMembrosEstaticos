using ClassesEMembrosEstaticos.Entidades;
using ClassesEMembrosEstaticos.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassesEMembrosEstaticos
{
    internal static class Program
    {
        private static List<Pessoa> pessoas = new List<Pessoa>()
        {
            new Pessoa("Adriano Vargas",new DateTime(2000,01,11), "65464654654"),
            new Cliente()
            {
                Nome = "Caroline Bianchini",
                Ativo = true,
                Cpf = "1454564564",
                Nascimento = new DateTime(2005,11,11),
                DataCadastro = new DateTime(2019,08,08),
                Genero = Genero.Feminino,
            },
            new Funcionario()
            {
                Nome = "Lulu beleza",
                Ativo = true,
                Nascimento= new DateTime(1954,01,15),
                Cpf = "6545646565456",
                Matricula = 156456,
                Cargo = "Estudante para estagiario"
            }            
        };


        static void Main(string[] args)
        {
            int opcao = 0;

            while (opcao == 0)
            {
                Console.WriteLine("Selecione dentre as opçoes: " +
                    "               \n\t1)Cadastro" +
                    "               \n\t2)Listar" +
                    "               \n\t3)Remover " +
                    "               \n\t4)Buscar" +
                    "               \n\t5)Editar");
                Menu menu = Enum.Parse<Menu>(Console.ReadLine(), true);
                Console.Clear();

                switch (menu)
                {
                    case Menu.Cadastro:
                        CadastroMenu();
                        break;
                    case Menu.Listar:
                        ImprimeDados();
                        break;
                    case Menu.Remover:
                        ImprimeFuncionarios();
                        break;
                    case Menu.Buscar:
                        break;
                    case Menu.Editar:
                        EditarPessoa();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Deseja continuar ? 1) Sim = 2) Não");
                opcao = int.Parse(Console.ReadLine());
                opcao = opcao > 1 ? 1 : 0;
            }
        }

        public  static void ImprimeFuncionarios()
        {
            List<Pessoa> funcioarios = pessoas.Where(x => x is Funcionario).ToList();
            foreach (var funcioario in funcioarios)
            {
                Console.WriteLine(funcioario.ImprimeDadosPessoais());
            }
        }

        public static void ImprimeDados()
        {
            foreach (var pessoa in pessoas)
            {
               Console.WriteLine(pessoa.ImprimeDadosPessoais());
            }
        }

        public static void EditarPessoa()
        {
            foreach(var pessoa in pessoas)
            {
                Console.WriteLine($"Id: {pessoa.Id} | Nome : {pessoa.Nome}");
            }

            Console.WriteLine("Informe o Id da pessoa que deseja editar");
            int id = int.Parse(Console.ReadLine());

            Pessoa p = pessoas.FirstOrDefault(p => p.Id == id);

            if(p is Cliente)
            {
                Cliente cliente = p as Cliente;
                Console.WriteLine("Informe a nova data de cadastro");
                cliente.DataCadastro = new DateTime(2030/12/12);
            }
            else if(p is Funcionario)
            {
                Funcionario funcionario = p as Funcionario;
                funcionario.Cargo = "Desenvolvedor Senior (do estagio)";
            }
        }

        public static void CadastroMenu()
        {
            Console.WriteLine("Selecione qual entidade deseja cadastrar");
            Console.WriteLine("\t1)Pessoas\n\t2)Clientes\n\t3)Funcionarios");
            SubMenu subMenu = Enum.Parse<SubMenu>(Console.ReadLine(), true);
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

            Console.Clear();
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
            Cliente cliente = new Cliente()
            {
                Nome = pessoa.Nome,
                Nascimento = pessoa.Nascimento,
                Ativo = pessoa.Ativo,
                Cpf = pessoa.Cpf,
            };

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
            Funcionario funcionario = new Funcionario()
            {
                Nome = pessoa.Nome,
                Nascimento = pessoa.Nascimento,
                Ativo = pessoa.Ativo,
                Cpf = pessoa.Cpf,
            };

            int matricula = int.Parse(Console.ReadLine());
            funcionario.Matricula = matricula;
            string cargo = Console.ReadLine();
            funcionario.Cargo = cargo;
            pessoas.Add(funcionario);
        }


    }
}

using System;

namespace ClassesEMembrosEstaticos.Entidades
{
    internal class Pessoa
    {
        public static int id;

        private int _id;

        public int Id
        {
            get { return _id; }
        }


        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }

        public Pessoa()
        {
            id++;
            _id = id;
        }

        public Pessoa(string nome, DateTime nascimento, string cpf) : this()
        {
            Nome = nome;
            Nascimento = nascimento;
            Cpf = cpf;
            Ativo = true;
        }


        public string ImprimePessoa()
        {
            return $"Nome: {Nome}\n" +
                $"Idade : {DateTime.Now.Year - Nascimento.Year}\n" +
                $"Cpf: {Cpf}";
        }
    }
}

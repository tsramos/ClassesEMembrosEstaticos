using System;
using System.Linq;
using ClassesEMembrosEstaticos.Enumeradores;

namespace ClassesEMembrosEstaticos.Entidades
{
    internal class Cliente : Pessoa
    {
        public DateTime DataCadastro { get; set; }
        public Genero Genero { get; set; }

        public void FazerCompras()
        {
            Console.WriteLine("Shoping");
        }

        public override string ImprimeDadosPessoais()
        {
            string partialDescription =  base.ImprimeDadosPessoais();
            return partialDescription + $"\n DataCadastro: {DataCadastro} \nGenero: {Genero}";
        }
    }
}

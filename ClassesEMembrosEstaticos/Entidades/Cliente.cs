using System;
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
    }
}

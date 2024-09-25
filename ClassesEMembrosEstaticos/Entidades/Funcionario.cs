using System;

namespace ClassesEMembrosEstaticos.Entidades
{
    internal class Funcionario : Pessoa
    {
        private static bool Entrada = true;
        public int Matricula { get; set; }
        public string Cargo { get; set; }

        public void BaterPonto()
        {
            if (Entrada)
            {
                Console.WriteLine($"Entrada as {DateTime.Now}");
                Entrada = false;
            }
            else
            {
                Console.WriteLine($"Saida as {DateTime.Now}");
                Entrada = true;
            }
        }
    }
}

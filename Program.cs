using System;
using Modulo1.Dto;
using Modulo1.Service;
using System.Collections.Generic;

namespace Modulo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome da oportunidade: ");
            string oportunidadeNome = Console.ReadLine();
            Console.WriteLine("Digite o salário da oportunidade: ");
            string oportunidadeSalario = Console.ReadLine();

            OportunidadeService oportunidadeService = new OportunidadeService();

            var oportunidade = oportunidadeService.Salvar(oportunidadeNome, oportunidadeSalario);

            oportunidade.Candidatos = new List<Candidato>();


            bool existeCandidato = true;

            while(existeCandidato)
            {
                Candidato candidato = new Candidato();
                Console.WriteLine("Digite o nome do candidato:");
                candidato.Nome = Console.ReadLine();
                Console.WriteLine("Digite o e-mail do candidato:");
                candidato.Email = Console.ReadLine();

                Console.WriteLine("Digite a nota do candidato:");

                string nota = Console.ReadLine();

                if (nota == "")
                    candidato.Nota = 0;
                else
                    candidato.Nota = Convert.ToInt32(nota);                

                if (candidato.Nome == "")
                    existeCandidato = false;
                else
                    oportunidade.Candidatos.Add(candidato);

            }

            Console.WriteLine("Digite o nome do candidato aprovado:");
            string nomeCandidatoAprovado = Console.ReadLine();

            oportunidade = oportunidadeService.AtribuirCandidatoAprovado(oportunidade, nomeCandidatoAprovado);


            Console.WriteLine($"A oportunidade {oportunidade.Nome} possui o salário no valor de {oportunidade.Salario}");


            if (oportunidade.Candidatos.Count > 0)
            {
                Console.WriteLine("Estes são os candidatos: ");

                oportunidade.Candidatos.ForEach(c => {
                    if (c.Aprovado)
                        Console.WriteLine($" - {c.Nome} ::: E-mail: {c.Email} ::: Nota: {c.Nota} [APROVADO]");
                    else
                        Console.WriteLine($" - {c.Nome} ::: E-mail: {c.Email} ::: Nota: {c.Nota}");
                });
            }

           
        }
    }
}
